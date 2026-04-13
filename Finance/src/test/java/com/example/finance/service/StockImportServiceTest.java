package com.example.finance.service;

import com.example.finance.model.StockPrice;
import com.example.finance.model.StockPriceRepository;
import com.example.finance.yahoo.ChartResponse;
import com.example.finance.yahoo.YahooFinanceClient;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.never;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
class StockImportServiceTest {

    @Mock
    private YahooFinanceClient yahooFinanceClient;

    @Mock
    private StockPriceRepository stockPriceRepository;

    @InjectMocks
    private StockImportService stockImportService;

    private ChartResponse validResponse;

    @BeforeEach
    void setUp() {
        validResponse = buildChartResponse("AAPL", 150.0, 155.0, 149.0, 153.0, 50_000_000L);
    }

    @Test
    void importDailyPrice_savesNewRecord() {
        when(yahooFinanceClient.fetchDailyPrice("AAPL")).thenReturn(Optional.of(validResponse));
        when(stockPriceRepository.findByTickerAndDate(any(), any())).thenReturn(Optional.empty());

        StockPrice expected = new StockPrice("AAPL", LocalDate.now(), BigDecimal.valueOf(150.0),
                BigDecimal.valueOf(155.0), BigDecimal.valueOf(149.0), BigDecimal.valueOf(153.0), 50_000_000L);
        when(stockPriceRepository.save(any())).thenReturn(expected);

        Optional<StockPrice> result = stockImportService.importDailyPrice("AAPL");

        assertThat(result).isPresent();
        assertThat(result.get().getTicker()).isEqualTo("AAPL");
        verify(stockPriceRepository).save(any(StockPrice.class));
    }

    @Test
    void importDailyPrice_skipsWhenRecordAlreadyExists() {
        when(yahooFinanceClient.fetchDailyPrice("AAPL")).thenReturn(Optional.of(validResponse));
        StockPrice existing = new StockPrice("AAPL", LocalDate.now(), null, null, null, BigDecimal.valueOf(153.0), null);
        when(stockPriceRepository.findByTickerAndDate(any(), any())).thenReturn(Optional.of(existing));

        Optional<StockPrice> result = stockImportService.importDailyPrice("AAPL");

        assertThat(result).isEmpty();
        verify(stockPriceRepository, never()).save(any());
    }

    @Test
    void importDailyPrice_returnsEmptyWhenFetchFails() {
        when(yahooFinanceClient.fetchDailyPrice("INVALID")).thenReturn(Optional.empty());

        Optional<StockPrice> result = stockImportService.importDailyPrice("INVALID");

        assertThat(result).isEmpty();
        verify(stockPriceRepository, never()).save(any());
    }

    @Test
    void importDailyPrices_returnsOnlySavedRecords() {
        ChartResponse msftResponse = buildChartResponse("MSFT", 300.0, 310.0, 295.0, 305.0, 30_000_000L);
        when(yahooFinanceClient.fetchDailyPrice("AAPL")).thenReturn(Optional.of(validResponse));
        when(yahooFinanceClient.fetchDailyPrice("MSFT")).thenReturn(Optional.of(msftResponse));
        when(stockPriceRepository.findByTickerAndDate(any(), any())).thenReturn(Optional.empty());
        when(stockPriceRepository.save(any())).thenAnswer(inv -> inv.getArgument(0));

        List<StockPrice> results = stockImportService.importDailyPrices(List.of("AAPL", "MSFT"));

        assertThat(results).hasSize(2);
    }

    @Test
    void importDailyPrice_returnsEmptyWhenChartResultIsEmpty() {
        ChartResponse emptyResponse = new ChartResponse();
        ChartResponse.Chart chart = new ChartResponse.Chart();
        chart.setResult(List.of());
        emptyResponse.setChart(chart);

        when(yahooFinanceClient.fetchDailyPrice("AAPL")).thenReturn(Optional.of(emptyResponse));

        Optional<StockPrice> result = stockImportService.importDailyPrice("AAPL");

        assertThat(result).isEmpty();
    }

    // ── helpers ──────────────────────────────────────────────────────────────

    private ChartResponse buildChartResponse(String ticker, double open, double high,
                                             double low, double close, long volume) {
        // Use a timestamp of 2024-01-15 00:00:00 UTC
        long timestamp = 1705276800L;

        ChartResponse.Quote quote = new ChartResponse.Quote();
        quote.setOpen(List.of(open));
        quote.setHigh(List.of(high));
        quote.setLow(List.of(low));
        quote.setClose(List.of(close));
        quote.setVolume(List.of(volume));

        ChartResponse.Indicators indicators = new ChartResponse.Indicators();
        indicators.setQuote(List.of(quote));

        ChartResponse.Result result = new ChartResponse.Result();
        result.setTimestamp(List.of(timestamp));
        result.setIndicators(indicators);

        ChartResponse.Chart chart = new ChartResponse.Chart();
        chart.setResult(List.of(result));

        ChartResponse response = new ChartResponse();
        response.setChart(chart);
        return response;
    }
}
