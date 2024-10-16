using Microsoft.EntityFrameworkCore;
using Test.October.Data;
using Test.October.Services.Interfaces;

namespace Test.October.Endpoints;

public static class TradeEndpoints
{
    public static void TradesEndpoints(this WebApplication app)
    {
        app.MapGet("/stats", async (TradeDbContext db, IStatsService service) =>
        {
            var trades = await db.Trade.ToListAsync();
            
            return Results.Content(service.GetStats(trades).ToString(), "text/html");
        });
        app.MapGet("/stats/{ticker}", async (TradeDbContext db, IStatsService service, string ticker) =>
        {
            var trades = await db.Trade.Where(x => x.ticker == ticker).ToListAsync();
            
            return Results.Content(service.GetStats(trades).ToString(), "text/html");
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
                .Where(t => t.ticker == ticker)
                .ToListAsync();
            
            var graph = service.Graph(trades);
            return Results.Content(graph.ToString(), "image/svg+xml");
        });
    }
}