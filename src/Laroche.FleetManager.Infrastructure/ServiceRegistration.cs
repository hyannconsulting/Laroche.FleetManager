using Laroche.FleetManager.Application.Interfaces.Repositories;
using Laroche.FleetManager.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Laroche.FleetManager.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories();
            return services;
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            var interfaceType = typeof(IBaseRepository<>);
            var interfaces = Assembly.GetAssembly(interfaceType)!.GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name) != null);

            var implementations = Assembly.GetAssembly(typeof(IBaseRepository<>))!.GetTypes();

            foreach (var item in interfaces)
            {
                var implementation = implementations.FirstOrDefault(p => p.GetInterface(item.Name) != null);

                if (implementation is not null)
                    services.AddScoped(item, implementation);
            }

            services.AddScoped<IDriversRepository, DriversRepository>();

        }
    }
}
