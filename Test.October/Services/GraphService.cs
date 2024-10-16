using System.Text;
using Test.October.Data.Models;
using Test.October.Services.Interfaces;

namespace Test.October.Services;

public class GraphService : IGraphService
{
    public StringBuilder Graph(List<Trade> trades)
    {
            var cumulativePnL = new List<double>();
            double currentPnL = 0;
            cumulativePnL.Add(0);

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

                currentPnL += pnl;
                cumulativePnL.Add(currentPnL);
            }
            
            const int width = 800;
            const int height = 400;
            const int padding = 50;
            
            var maxPnL = cumulativePnL.Max();
            var minPnL = cumulativePnL.Min();
            var maxTrades = cumulativePnL.Count;
            
            var svgBuilder = new StringBuilder();
            svgBuilder.AppendLine($"<svg width='{width}' height='{height}' xmlns='http://www.w3.org/2000/svg'>");
            
            svgBuilder.AppendLine(
                $"<line x1='{padding}' y1='{height - padding}' x2='{width - padding}' y2='{height - padding}' stroke='black' />");
            svgBuilder.AppendLine(
                $"<line x1='{padding}' y1='{padding}' x2='{padding}' y2='{height - padding}' stroke='black' />");
            
            var xStep = (width - 2 * padding) / (double)(maxTrades - 1);
            var yStep = (height - 2 * padding) / (maxPnL - minPnL);
            
            for (var i = 0; i < cumulativePnL.Count - 1; i++)
            {
                var x1 = padding + i * xStep;
                var y1 = height - padding - (cumulativePnL[i] - minPnL) * yStep;
                var x2 = padding + (i + 1) * xStep;
                var y2 = height - padding - (cumulativePnL[i + 1] - minPnL) * yStep;

                svgBuilder.AppendLine(
                    $"<line x1='{x1}' y1='{y1}' x2='{x2}' y2='{y2}' stroke='blue' stroke-width='2' />");
            }
            
            return svgBuilder.AppendLine("</svg>");
    }
}