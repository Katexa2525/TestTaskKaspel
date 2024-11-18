using Domain.Models;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
  public class RepositoryContext : DbContext
  {
    public RepositoryContext(DbContextOptions options) : base(options)
    {
      //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Order>()
          .HasMany(o => o.OrdBooks)
          .WithOne()
          .HasForeignKey(b => b.OrderId)
          .OnDelete(DeleteBehavior.Cascade);

      //modelBuilder.Entity<Book>()
      //   .HasMany(o => o.OrdBooks)
      //   .WithOne()
      //   .HasForeignKey(b => b.BookId);

      modelBuilder.ApplyConfiguration(new BookConfiguration());
      modelBuilder.ApplyConfiguration(new OrderConfiguration());
      modelBuilder.ApplyConfiguration(new OrdBookConfiguration());

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book>? Books { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrdBook>? OrdBooks { get; set; }
  }
}
