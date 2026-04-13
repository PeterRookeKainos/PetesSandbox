package com.example.finance.controller;

import com.example.finance.model.StockPrice;
import com.example.finance.model.StockPriceRepository;
import com.example.finance.service.StockImportService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

/**
 * REST API for triggering stock price imports and querying stored prices.
 */
@RestController
@RequestMapping("/stocks")
public class StockImportController {

    private final StockImportService stockImportService;
    private final StockPriceRepository stockPriceRepository;

    public StockImportController(StockImportService stockImportService,
                                 StockPriceRepository stockPriceRepository) {
        this.stockImportService = stockImportService;
        this.stockPriceRepository = stockPriceRepository;
    }

    /**
     * Triggers an on-demand import of the latest daily price for a single ticker.
     *
     * @param ticker the stock ticker symbol (e.g. "AAPL")
     * @return the saved StockPrice, or 204 No Content if the record already existed
     */
    @PostMapping("/{ticker}/import")
    public ResponseEntity<StockPrice> importTicker(@PathVariable String ticker) {
        return stockImportService.importDailyPrice(ticker.toUpperCase())
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.noContent().build());
    }

    /**
     * Returns all stored daily prices for a given ticker, newest first.
     *
     * @param ticker the stock ticker symbol
     * @return list of stock prices
     */
    @GetMapping("/{ticker}")
    public List<StockPrice> getPrices(@PathVariable String ticker) {
        return stockPriceRepository.findByTickerOrderByDateDesc(ticker.toUpperCase());
    }

    @ExceptionHandler(IllegalArgumentException.class)
    public ResponseEntity<String> handleIllegalArgument(IllegalArgumentException ex) {
        return ResponseEntity.badRequest().body(ex.getMessage());
    }
}
