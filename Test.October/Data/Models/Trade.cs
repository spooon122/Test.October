using System.ComponentModel.DataAnnotations;

namespace Test.October.Data.Models;

public class Trade
{
    public long id { get; set; }
    public string ticker { get; set; }
    
    [RegularExpression("^(BUY|SELL)$", ErrorMessage = "TradeType must be either 'BUY' or 'SELL'")]
    public required string side { get; set; }
    public double openprice { get; set; }
    public double closeprice { get; set; }
    public double quantity { get; set; }
    public DateTime opentime { get; set; }
    public DateTime closetime { get; set; }
}