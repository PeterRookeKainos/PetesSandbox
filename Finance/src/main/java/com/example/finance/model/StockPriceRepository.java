package com.example.finance.model;

import org.springframework.data.jpa.repository.JpaRepository;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

public interface StockPriceRepository extends JpaRepository<StockPrice, Long> {

    List<StockPrice> findByTickerOrderByDateDesc(String ticker);

    Optional<StockPrice> findByTickerAndDate(String ticker, LocalDate date);
}
