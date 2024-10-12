namespace Test.October.Data.Models;

public class Trade
{
    public Guid ID { get; set; }
    public string Ticker { get; set; }
    public string Side { get; set; }
    public float OpenPrice { get; set; }
    public float ClosePrice { get; set; }
    public float Quantity { get; set; }
    public DateTime OpenTime { get; set; }
    public DateTime CloseTime { get; set; }
}