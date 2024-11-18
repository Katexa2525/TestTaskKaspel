using Microsoft.AspNetCore.HttpOverrides;
using TestTaskKaspelAn.Extensions;

string? pathDirectoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(pathDirectoryName + "//appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAuthentication();
builder.Services.ConfigureValidator();

//builder.Services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// обработчик ошибок с помощью RequstDelegat
app.UseExceptionHandlerMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
  ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

//app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();