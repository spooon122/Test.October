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
            : await db.Trade.Where(t => t.ticker == ticker).ToListAsync();

        foreach (var trade in trades)
        {
            double pnl;
            if (trade.side == "BUY")
            {
                pnl = 100 * (trade.closeprice - trade.openprice) / trade.openprice;
            }
            else
            {
                pnl = -100 * (trade.closeprice - trade.openprice) / trade.openprice;
            }

            TradesWithPnL.Add(new TradeWithPnL
            {
                id = trade.id,
                ticker = trade.ticker,
                openprice = trade.openprice,
                closeprice = trade.closeprice,
                quantity = trade.quantity,
                opentime = trade.opentime,
                closetime = trade.closetime,
                side = trade.side,
                PnL = pnl
            });
        }
    }
}