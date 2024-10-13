using Test.October;
using Test.October.Data;
using Test.October.Endpoints;
using Test.October.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TradeDbContext>();
builder.Services.AddScoped<IGraphService, GraphService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}
app.UseHttpsRedirection();
app.TradesEndpoints();
app.Run();