using Laroche.FleetManager.Application.Interfaces.Service;
using Laroche.FleetManager.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
namespace Laroche.FleetManager.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterDomainsService(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDomains();
            return services;
        }

        private static void RegisterDomains(this IServiceCollection services)
        {
            var interfaceType = typeof(IBaseService<>);
            var interfaces = Assembly.GetAssembly(interfaceType)!.GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name) != null);

            var implementations = Assembly.GetAssembly(typeof(IBaseService<>))!.GetTypes();

            foreach (var item in interfaces)
            {
                var implementation = implementations.FirstOrDefault(p => p.GetInterface(item.Name) != null);

                if (implementation is not null)
                    services.AddScoped(item, implementation);
            }

            // Enregistrement de IDriversService et DriversService
            services.AddScoped<IDriversService, DriversService>();
        }
    }
}
