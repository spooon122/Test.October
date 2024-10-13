using Microsoft.EntityFrameworkCore;
using Test.October.Data;
using Test.October.Services;

namespace Test.October.Endpoints;

public static class TradeEndpoints
{
    public static void TradesEndpoints(this WebApplication app)
    {
        app.MapGet("/stats", async (TradeDbContext db) => await db.Trade.ToListAsync());
        app.MapGet("/stats/{ticker}",
            async (TradeDbContext db, string ticker) =>
            {
                return await db.Trade.Where(x => x.Ticker == ticker).ToListAsync();
            });

        app.MapGet("/graph", async (TradeDbContext db, IGraphService service) =>
        {
            var trades = await db.Trade.ToListAsync();
            var graph = service.Graph(trades);
            return Results.Content(graph.ToString(), "image/svg+xml");
        });
        app.MapGet("/graph/{ticker}", async (TradeDbContext db, IGraphService service, string ticker) =>
        {
            var trades = await db.Trade
                .Where(t => t.Ticker == ticker)
                .ToListAsync();
            var graph = service.Graph(trades);
            return Results.Content(graph.ToString(), "image/svg+xml");
        });
    }
}