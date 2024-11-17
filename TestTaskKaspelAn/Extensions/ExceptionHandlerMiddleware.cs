using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace TestTaskKaspelAn.Extensions
{
  public class ExceptionHandlerMiddleware
  {
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next.Invoke(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
      }
    }

    private async Task HandleExceptionMessageAsync(HttpContext context, Exception ex)
    {
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      context.Response.ContentType = "application/json";
      await context.Response.WriteAsync(JsonSerializer.Serialize(
        new ProblemDetails()
        {
          Status = context.Response.StatusCode,
          Title = !string.IsNullOrEmpty(ex.Message) ? ex.Message : string.Empty
        }).ToString());
    }
  }
}
