CREATE TABLE trades_table
(
    ID         bigint GENERATED ALWAYS AS IDENTITY,
    Ticker     text,
    Side       text,
    OpenPrice  double precision,
    ClosePrice double precision,
    Quantity   double precision,
    OpenTime   timestamp,
    CloseTime  timestamp
);