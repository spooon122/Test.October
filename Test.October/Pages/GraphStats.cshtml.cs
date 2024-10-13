using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.October.Data;
using Test.October.Data.Models;

namespace Test.October.Pages;

public class GraphStats(TradeDbContext db) : PageModel
{
    public List<TradeWithPnL> TradesWithPnL { get; set; } = [];

    public async Task OnGetAsync(string? ticker)
    {
        var trades = string.IsNullOrEmpty(ticker) 
            ? await db.Trade.ToListAsync() 
            : await db.Trade.Where(t => t.Ticker == ticker).ToListAsync();

        foreach (var trade in trades)
        {
            double pnl;
            if (trade.Side == "BUY")
            {
                pnl = 100 * (trade.ClosePrice - trade.OpenPrice) / trade.OpenPrice;
            }
            else
            {
                pnl = -100 * (trade.OpenPrice - trade.ClosePrice) / trade.OpenPrice;
            }

            TradesWithPnL.Add(new TradeWithPnL
            {
                ID = trade.ID,
                Ticker = trade.Ticker,
                OpenPrice = trade.OpenPrice,
                ClosePrice = trade.ClosePrice,
                Quantity = trade.Quantity,
                OpenTime = trade.OpenTime,
                CloseTime = trade.CloseTime,
                Side = trade.Side,
                PnL = pnl
            });
        }
    }
}