using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.October.Data;
using Test.October.Data.Models;

namespace Test.October.Pages;

public class TradesStats(TradeDbContext db) : PageModel
{
    public List<Trade> Trades { get; set; } = [];
    public async Task OnGetAsync(string? ticker)
    {
        Trades = !string.IsNullOrEmpty(ticker)
            ? await db.Trade.Where(t => t.ticker == ticker).ToListAsync()
            : await db.Trade.ToListAsync();
    }
}