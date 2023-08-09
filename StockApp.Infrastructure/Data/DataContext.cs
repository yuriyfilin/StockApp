using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;

namespace StockApp.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Acceptance> Acceptance { get; set; }
    public DbSet<AcceptanceGoods> AcceptanceGoods { get; set; }
    public DbSet<Good> Good { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<SaleGoods> SaleGoods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>(entity =>
        {
            entity.Property(e => e.PurchasePrice).HasPrecision(20, 2);
            entity.Property(e => e.SellingPrice).HasPrecision(20, 2);
        });

        modelBuilder.Entity<AcceptanceGoods>(entity =>
        {
            entity.HasOne(d => d.Acceptance)
                .WithMany(p => p.AcceptanceGoods)
                .HasForeignKey(d => d.AcceptanceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AcceptanceGoods_Acceptance");

            entity.HasOne(d => d.Good)
                .WithMany(p => p.AcceptanceGoods)
                .HasForeignKey(d => d.GoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AcceptanceGoods_Good");
        });

        modelBuilder.Entity<SaleGoods>(entity =>
        {
            entity.HasOne(d => d.Sale)
                .WithMany(p => p.SaleGoods)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SaleGoods_Sale");

            entity.HasOne(d => d.Good)
                .WithMany(p => p.SaleGoods)
                .HasForeignKey(d => d.GoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SaleGoods_Good");
        });

    }
}
