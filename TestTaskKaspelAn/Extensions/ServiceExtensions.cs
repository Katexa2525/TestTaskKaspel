using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.Service;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestTaskKaspelAn.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureCors(this IServiceCollection services) =>
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("X-Pagination"));
      });

    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<RepositoryContext>(opts => opts.UseMySQL(configuration.GetConnectionString("MySqlConnection")));
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
      services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
      services.AddScoped<IServiceManager, ServiceManager>();

    //public static void ConfigureValidator(this IServiceCollection services)
    //{
    //  //services.AddFluentValidationAutoValidation();
    //  services.AddScoped<IValidator<Book>, BookValidator>();
    //  services.AddScoped<IValidator<Author>, AuthorValidator>();
    //  services.AddScoped<IValidator<UserBook>, UserBookValidation>();
    //}

  }
}
