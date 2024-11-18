using Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TestTaskKaspelAn.ContextFactory
{
  public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
  {
    public RepositoryContext CreateDbContext(string[] args)
    {
      var configuration = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .Build();
      var builder = new DbContextOptionsBuilder<RepositoryContext>()
                        .UseMySql(configuration.GetConnectionString("MySqlConnection"),
                                  ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlConnection")));
      return new RepositoryContext(builder.Options);
    }
  }
}
