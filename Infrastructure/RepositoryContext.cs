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
    }

    public DbSet<Book>? Books { get; set; }
    public DbSet<Order>? Orders { get; set; }
  }
}
