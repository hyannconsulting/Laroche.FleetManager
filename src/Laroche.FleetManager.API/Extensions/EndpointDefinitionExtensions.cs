using System.Reflection;

namespace Laroche.FleetManager.API.Extensions
{
    public static class EndpointDefinitionExtensions
    {
        public static void AddEndpointDefinitions(
    this IServiceCollection services, IConfiguration configuration)
    => AddEndpointDefinitions(services, configuration, Assembly.GetExecutingAssembly());

        public static void AddEndpointDefinitions(
           this IServiceCollection services, IConfiguration configuration, params Assembly[] scanAssemblies)
        {
            var endpointDefinitions = new List<IEndpointDefinition>();

            foreach (var assembly in scanAssemblies)
            {
                endpointDefinitions.AddRange(
                    assembly.ExportedTypes
                        .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IEndpointDefinition>()
                );
            }

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.DefineServices(services, configuration);
            }

            services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
        }


        public static void UseEndpointDefinitions(this WebApplication app)
        {
            var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

            foreach (var endpointDefinition in definitions)
            {
                endpointDefinition.DefineEndpoints(app);
            }
        }
    }

}
