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
          .HasMany(o => o.Books)
          .WithOne(b => b.Order)
          .HasForeignKey(b => b.OrderId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.ApplyConfiguration(new BookConfiguration());
      modelBuilder.ApplyConfiguration(new OrderConfiguration());

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book>? Books { get; set; }
    public DbSet<Order>? Orders { get; set; }
  }
}
