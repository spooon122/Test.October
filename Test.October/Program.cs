using Microsoft.EntityFrameworkCore;
using Test.October;
using Test.October.Data;
using Test.October.Endpoints;
using Test.October.Services;
using Test.October.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TradeDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("TradeStatsDB")));

builder.Services.AddScoped<IGraphService, GraphService>();
builder.Services.AddScoped<IStatsService, StatsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.TradesEndpoints();

app.Run();