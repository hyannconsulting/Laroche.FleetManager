using Laroche.FleetManager.API.Extensions;
using Laroche.FleetManager.Application;
using Laroche.FleetManager.Infrastructure;
using Laroche.FleetManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDomainsService(builder.Configuration);
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connexionString =
    builder.Configuration["Database:ConnectionString"]
        ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContextFactory<FleetManagerDbContext>(options =>
    options.UseSqlServer(connexionString));

// Add/Configure endpoints dependencies
builder.Services.AddEndpointDefinitions(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "Laroche.FleetManager API");
    });
}

app.UseHttpsRedirection();



//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");


// Map endpoints
app.UseEndpointDefinitions();

await app.RunAsync();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
