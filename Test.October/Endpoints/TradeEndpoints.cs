namespace Test.October.Endpoints;

public static class TradeEndpoints
{
    public static void TradesEndpoints(this WebApplication app)
    {
        app.MapGet("/stats", () => Results.Redirect("/TradesStats"));
        app.MapGet("/stats/{ticker}", (string ticker) => Results.Redirect($"/TradesStats?ticker={ticker}"));
        app.MapGet("/graph", () => Results.Redirect("/GraphStats"));
        app.MapGet("/graph/{ticker}", (string ticker) => Results.Redirect($"/GraphStats?ticker={ticker}"));
    }
}