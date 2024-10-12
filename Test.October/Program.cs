using Microsoft.EntityFrameworkCore;
using Test.October.Data;
using Test.October.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TradeDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("TradeStatsDB")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/user", async (TradeDbContext db) =>
{
    var trade = new Trade
    {
        Quantity = 1,
        Side = "BUY",
        ClosePrice = 1,
        OpenTime = DateTime.UtcNow,
        CloseTime = DateTime.UtcNow,
        OpenPrice = 1,
        Ticker = "123"
    };
    await db.Trade.AddAsync(trade);
    return Results.Ok();
});

app.Run();