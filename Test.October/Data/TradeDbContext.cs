using Microsoft.EntityFrameworkCore;
using Test.October.Data.Models;

namespace Test.October.Data;

public class TradeDbContext(DbContextOptions<TradeDbContext> options) : DbContext(options)
{
    public DbSet<Trade> Trade { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Trade>()
            .HasKey(x => x.ID);

        modelBuilder.Entity<Trade>()
            .ToTable("trades_table");
    }
}