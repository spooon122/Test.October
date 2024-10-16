using System.Text;
using Test.October.Data.Models;
using Test.October.Services.Interfaces;

namespace Test.October.Services;

public class StatsService : IStatsService
{
    public StringBuilder GetStats(List<Trade> trades)
    {
            var html = new StringBuilder();

            html.Append("<!DOCTYPE html>");
            html.Append("<html lang='en'>");
            html.Append("<head>");
            html.Append("<meta charset='UTF-8'>");
            html.Append("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
            html.Append("<title>Trades Statistics</title>");
            html.Append("<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css'>");
            html.Append("<style>");
            html.Append("body { font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 20px; }");
            html.Append("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            html.Append("th, td { padding: 12px; text-align: left; border-bottom: 1px solid #ddd; }");
            html.Append("th { background-color: #4CAF50; color: white; }");
            html.Append("tr:hover { background-color: #f1f1f1; }");
            html.Append("</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append("<h1>Trades Statistics</h1>");
            html.Append("<table>");
            html.Append("<thead><tr>" +
                "<th>ID</th>" +
                "<th>Ticker</th>" +
                "<th>Side</th>" +
                "<th>OpenPrice</th>" +
                "<th>ClosePrice</th>" +
                "<th>Quantity</th>" +
                "<th>OpenTime</th>" +
                "<th>CloseTime</th></tr></thead>");
            html.Append("<tbody>");

            foreach (var trade in trades)
            {
                html.Append($"<tr><td>{trade.id}</td>" +
                    $"<td>{trade.ticker}</td>" +
                    $"<td>{trade.side}</td>" +
                    $"<td>{trade.openprice}</td>" +
                    $"<td>{trade.closeprice}</td>" +
                    $"<td>{trade.quantity}</td>" +
                    $"<td>{trade.opentime}</td>" +
                    $"<td>{trade.closetime}</td>" +
                    $"</tr>");
            }

            return html.Append("</tbody></table></body></html>");
    }
}