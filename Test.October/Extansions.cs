using Microsoft.EntityFrameworkCore;
using Test.October.Data;

namespace Test.October;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        
        using TradeDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<TradeDbContext>();
        
        dbContext.Database.Migrate();
    }
}