DO
$$
    DECLARE
        NumberOfTrades INT := 10;
        OpenPrice      FLOAT;
        OpenTime       TIMESTAMP;
    BEGIN
        FOR i IN 1..NumberOfTrades
            LOOP
                OpenPrice := round((random() * (100 - 10) + 10)::numeric, 2);

                OpenTime := NOW() - INTERVAL '1 hour' * (random() * (24 - 8) + 8);

                INSERT INTO trades_table ("ticker", "side", "openprice", "closeprice", "quantity", "opentime",
                                          "closetime")
                VALUES ((ARRAY ['Ticker1', 'Ticker2', 'Ticker3', 'Ticker4', 'Ticker5'])[floor(random() * 5 + 1)],
                        (ARRAY ['BUY', 'SELL'])[floor(random() * 2 + 1)],
                        OpenPrice,
                        round((OpenPrice * (1 + (random() * 20 - 10) / 100))::numeric, 2),
                        round((random() * (25 - 1) + 1)::numeric, 2),
                        OpenTime,
                        OpenTime + INTERVAL '1 hour' * (random() * 3 + 1));
            END LOOP;
    END
$$;