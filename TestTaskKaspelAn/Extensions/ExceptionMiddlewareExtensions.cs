using Microsoft.AspNetCore.Diagnostics;

namespace TestTaskKaspelAn.Extensions
{
  public static class ExceptionMiddlewareExtensions
  {
    public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
      app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
  }
}
