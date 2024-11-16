using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
  public class RepositoryContext : DbContext
  {
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Order>()
          .HasMany(o => o.Books)
          .WithOne(b => b.Order)
          .HasForeignKey(b => b.OrderId)
          .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Book>? Books { get; set; }
    public DbSet<Order>? Orders { get; set; }
  }
}
