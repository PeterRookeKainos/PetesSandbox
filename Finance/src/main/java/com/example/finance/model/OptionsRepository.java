package com.example.finance.model;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface OptionsRepository extends JpaRepository<Options, Long> {

    List<Options> findByTicker(String ticker);

    List<Options> findByType(OptionType type);
}
