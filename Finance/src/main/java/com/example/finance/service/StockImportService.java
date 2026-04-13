package com.example.finance.service;

import com.example.finance.model.StockPrice;
import com.example.finance.model.StockPriceRepository;
import com.example.finance.yahoo.ChartResponse;
import com.example.finance.yahoo.YahooFinanceClient;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.time.Instant;
import java.time.LocalDate;
import java.time.ZoneOffset;
import java.util.ArrayList;
import java.util.List;

/**
 * Fetches daily stock prices from Yahoo Finance and persists them using JPA.
 * A scheduled job runs automatically each weekday at 18:00 UTC (after US market close).
 */
@Service
public class StockImportService {

    private static final Logger log = LoggerFactory.getLogger(StockImportService.class);

    private final YahooFinanceClient yahooFinanceClient;
    private final StockPriceRepository stockPriceRepository;

    @Value("${finance.tickers:AAPL,MSFT,GOOGL}")
    private List<String> tickers;

    public StockImportService(YahooFinanceClient yahooFinanceClient,
                              StockPriceRepository stockPriceRepository) {
        this.yahooFinanceClient = yahooFinanceClient;
        this.stockPriceRepository = stockPriceRepository;
    }

    /**
     * Scheduled job: imports daily prices for all configured tickers.
     * Runs at 18:00 UTC Monday–Friday (after NYSE close).
     */
    @Scheduled(cron = "${finance.import.cron:0 0 18 * * MON-FRI}", zone = "UTC")
    public void importDailyPricesScheduled() {
        log.info("Running scheduled daily stock price import for {} tickers", tickers.size());
        importDailyPrices(tickers);
    }

    /**
     * Imports the latest daily price for each of the given ticker symbols.
     *
     * @param symbols list of ticker symbols to import
     * @return the list of stock prices that were saved (new records only)
     */
    public List<StockPrice> importDailyPrices(List<String> symbols) {
        List<StockPrice> saved = new ArrayList<>();
        for (String ticker : symbols) {
            try {
                importDailyPrice(ticker).ifPresent(saved::add);
            } catch (Exception e) {
                log.error("Unexpected error importing price for '{}': {}", ticker, e.getMessage());
            }
        }
        return saved;
    }

    /**
     * Imports the latest daily price for a single ticker symbol.
     *
     * @param ticker the stock ticker symbol
     * @return the saved StockPrice, or empty if the record already exists or the fetch failed
     */
    public java.util.Optional<StockPrice> importDailyPrice(String ticker) {
        return yahooFinanceClient.fetchDailyPrice(ticker)
                .flatMap(response -> parseStockPrice(ticker, response))
                .flatMap(stockPrice -> {
                    if (stockPriceRepository.findByTickerAndDate(stockPrice.getTicker(), stockPrice.getDate()).isPresent()) {
                        log.debug("Record already exists for {} on {}, skipping", ticker, stockPrice.getDate());
                        return java.util.Optional.empty();
                    }
                    StockPrice persisted = stockPriceRepository.save(stockPrice);
                    log.info("Saved stock price for {} on {}: close={}", ticker, persisted.getDate(), persisted.getClose());
                    return java.util.Optional.of(persisted);
                });
    }

    private java.util.Optional<StockPrice> parseStockPrice(String ticker, ChartResponse response) {
        if (response.getChart() == null
                || response.getChart().getResult() == null
                || response.getChart().getResult().isEmpty()) {
            log.warn("No chart result returned for ticker '{}'", ticker);
            return java.util.Optional.empty();
        }

        ChartResponse.Result result = response.getChart().getResult().get(0);

        if (result.getTimestamp() == null || result.getTimestamp().isEmpty()) {
            log.warn("No timestamp data for ticker '{}'", ticker);
            return java.util.Optional.empty();
        }

        if (result.getIndicators() == null
                || result.getIndicators().getQuote() == null
                || result.getIndicators().getQuote().isEmpty()) {
            log.warn("No quote data for ticker '{}'", ticker);
            return java.util.Optional.empty();
        }

        int lastIndex = result.getTimestamp().size() - 1;
        long epochSeconds = result.getTimestamp().get(lastIndex);
        LocalDate date = Instant.ofEpochSecond(epochSeconds).atZone(ZoneOffset.UTC).toLocalDate();

        ChartResponse.Quote quote = result.getIndicators().getQuote().get(0);
        BigDecimal open = toBigDecimal(quote.getOpen(), lastIndex);
        BigDecimal high = toBigDecimal(quote.getHigh(), lastIndex);
        BigDecimal low = toBigDecimal(quote.getLow(), lastIndex);
        BigDecimal close = toBigDecimal(quote.getClose(), lastIndex);
        Long volume = toVolume(quote.getVolume(), lastIndex);

        return java.util.Optional.of(new StockPrice(ticker, date, open, high, low, close, volume));
    }

    private BigDecimal toBigDecimal(List<Double> values, int index) {
        if (values == null || index >= values.size() || values.get(index) == null) {
            return null;
        }
        return BigDecimal.valueOf(values.get(index));
    }

    private Long toVolume(List<Long> values, int index) {
        if (values == null || index >= values.size()) {
            return null;
        }
        return values.get(index);
    }
}
