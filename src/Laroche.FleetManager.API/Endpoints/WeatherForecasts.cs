using Laroche.FleetManager.API.Extensions;

namespace Laroche.FleetManager.API.Endpoints
{
    public class WeatherForecasts : IEndpointDefinition
    {
        private List<string> summaries = new()
                  {
                  "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
              };

        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Count)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithTags("WeatherForecast");
        }



        public void DefineServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
        //var summaries = new[]
        //          {
        //          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //      };
    }


}
