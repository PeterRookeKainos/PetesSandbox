package com.example.finance.yahoo;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.Optional;
import java.util.regex.Pattern;

/**
 * Fetches daily stock price data from the Yahoo Finance v8 chart API.
 */
@Component
public class YahooFinanceClient {

    private static final Logger log = LoggerFactory.getLogger(YahooFinanceClient.class);

    private static final String BASE_URL = "https://query1.finance.yahoo.com/v8/finance/chart/{symbol}";

    /** Only allow well-formed ticker symbols: 1–10 uppercase letters, digits, dots, or hyphens. */
    private static final Pattern TICKER_PATTERN = Pattern.compile("^[A-Z0-9.\\-]{1,10}$");

    private final RestTemplate restTemplate;

    public YahooFinanceClient(RestTemplate restTemplate) {
        this.restTemplate = restTemplate;
    }

    /**
     * Fetches the most recent daily OHLCV bar for the given ticker symbol.
     *
     * @param ticker the stock ticker symbol (e.g. "AAPL")
     * @return the chart response, or empty if the request fails
     * @throws IllegalArgumentException if the ticker contains disallowed characters
     */
    public Optional<ChartResponse> fetchDailyPrice(String ticker) {
        if (!TICKER_PATTERN.matcher(ticker).matches()) {
            throw new IllegalArgumentException("Invalid ticker symbol: " + ticker);
        }

        String url = UriComponentsBuilder
                .fromUriString(BASE_URL)
                .queryParam("interval", "1d")
                .queryParam("range", "1d")
                .buildAndExpand(ticker)
                .toUriString();

        try {
            ChartResponse response = restTemplate.getForObject(url, ChartResponse.class);
            return Optional.ofNullable(response);
        } catch (Exception e) {
            log.error("Failed to fetch daily price for ticker '{}': {}", ticker, e.getMessage());
            return Optional.empty();
        }
    }
}
