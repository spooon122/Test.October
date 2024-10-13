using System.ComponentModel.DataAnnotations;

namespace Test.October.Data.Models;

public class Trade
{
    public long ID { get; set; }
    public string Ticker { get; set; }
    
    [RegularExpression("^(BUY|SELL)$", ErrorMessage = "TradeType must be either 'BUY' or 'SELL'")]
    public required string Side { get; set; }
    public double OpenPrice { get; set; }
    public double ClosePrice { get; set; }
    public double Quantity { get; set; }
    public DateTime OpenTime { get; set; }
    public DateTime CloseTime { get; set; }
}