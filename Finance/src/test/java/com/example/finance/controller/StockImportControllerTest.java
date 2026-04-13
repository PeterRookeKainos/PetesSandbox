package com.example.finance.controller;

import com.example.finance.model.StockPrice;
import com.example.finance.model.StockPriceRepository;
import com.example.finance.service.StockImportService;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.test.web.servlet.MockMvc;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.jsonPath;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(StockImportController.class)
class StockImportControllerTest {

    @Autowired
    private MockMvc mockMvc;

    @MockBean
    private StockImportService stockImportService;

    @MockBean
    private StockPriceRepository stockPriceRepository;

    @Test
    void importTicker_returns200WithSavedPrice() throws Exception {
        StockPrice price = new StockPrice("AAPL", LocalDate.of(2024, 1, 15),
                BigDecimal.valueOf(150.0), BigDecimal.valueOf(155.0),
                BigDecimal.valueOf(149.0), BigDecimal.valueOf(153.0), 50_000_000L);

        when(stockImportService.importDailyPrice("AAPL")).thenReturn(Optional.of(price));

        mockMvc.perform(post("/stocks/AAPL/import"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.ticker").value("AAPL"))
                .andExpect(jsonPath("$.close").value(153.0));
    }

    @Test
    void importTicker_returns204WhenAlreadyImported() throws Exception {
        when(stockImportService.importDailyPrice("AAPL")).thenReturn(Optional.empty());

        mockMvc.perform(post("/stocks/AAPL/import"))
                .andExpect(status().isNoContent());
    }

    @Test
    void importTicker_normalisesTickerToUpperCase() throws Exception {
        when(stockImportService.importDailyPrice("AAPL")).thenReturn(Optional.empty());

        mockMvc.perform(post("/stocks/aapl/import"))
                .andExpect(status().isNoContent());
    }

    @Test
    void getPrices_returnsStoredPrices() throws Exception {
        StockPrice price = new StockPrice("AAPL", LocalDate.of(2024, 1, 15),
                BigDecimal.valueOf(150.0), BigDecimal.valueOf(155.0),
                BigDecimal.valueOf(149.0), BigDecimal.valueOf(153.0), 50_000_000L);

        when(stockPriceRepository.findByTickerOrderByDateDesc("AAPL")).thenReturn(List.of(price));

        mockMvc.perform(get("/stocks/AAPL"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$[0].ticker").value("AAPL"))
                .andExpect(jsonPath("$[0].date").value("2024-01-15"));
    }

    @Test
    void getPrices_returnsEmptyListWhenNoneFound() throws Exception {
        when(stockPriceRepository.findByTickerOrderByDateDesc("XYZ")).thenReturn(List.of());

        mockMvc.perform(get("/stocks/XYZ"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$").isEmpty());
    }

    @Test
    void importTicker_returns400ForInvalidTicker() throws Exception {
        when(stockImportService.importDailyPrice("INVALID!"))
                .thenThrow(new IllegalArgumentException("Invalid ticker symbol: INVALID!"));

        mockMvc.perform(post("/stocks/INVALID!/import"))
                .andExpect(status().isBadRequest());
    }
}
