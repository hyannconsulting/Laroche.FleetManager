using Laroche.FleetManager.API.Extensions;
using Laroche.FleetManager.Application.Interfaces.Service;
using Laroche.FleetManager.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laroche.FleetManager.API.Endpoints
{
    public class DriversEndpoints : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            //app.MapGet("/api/drivers", async (IDriversRepository repository) =>
            //{
            //    return await repository.GetAllAsync();
            //});


            //app.MapGet("/api/drivers/{id}", async (IDriversRepository repository, int id) =>
            //{
            //    return await repository.GetByIdAsync(id);
            //});

            //app.MapPost("/api/drivers", async (IDriversRepository repository, Driver driver) =>
            //{
            //    return await repository.AddAsync(driver);
            //});

            //{
            //    return await repository.Update(id, driver);
            //});
            //app.MapDelete("/api/drivers/{id}", async (IDriversRepository repository, int id) =>
            //{
            //    return await repository.DeleteDriver(id);
            //});


            app.MapPost("/api/v1/drivers", AddDriver);

        }

        public async static Task<IResult> AddDriver(
            [FromServices] IDriversService service,
            [FromBody] Driver driver)
        {
            var result = await service.AddAsync(driver.Name, driver.Surname, driver.LicenseNumber, driver.LicenseState, driver.LicenseExpirationDate);
            return TypedResults.Ok(result);
        }

        public void DefineServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDriversService, DriversService>();
        }

        public record Driver(string Name, string Surname, string LicenseNumber, string LicenseState, string LicenseExpirationDate);
    }

}
