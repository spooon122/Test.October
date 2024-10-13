using Microsoft.EntityFrameworkCore;
using Test.October.Data;
using Test.October.Services;

namespace Test.October.Endpoints;

public static class TradeEndpoints
{
    public static void TradesEndpoints(this WebApplication app)
    {
        app.MapGet("/stats", async (TradeDbContext db) => await db.Trade.ToListAsync());
        app.MapGet("/stats/{ticker}", async (TradeDbContext db, string ticker) =>
        {
            return await db.Trade.Where(x => x.Ticker == ticker).ToListAsync();
        });
    }
}