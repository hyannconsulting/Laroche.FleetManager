using Laroche.FleetManager.Application.Interfaces.Repositories;

namespace Laroche.FleetManager.Application.Services
{
    public class VehiculesService(IVehiculesRepository repository) :
      BaseService<IVehiculesRepository, Domain.Entities.Vehicule>(repository)
    {

    }
}
