using Laroche.FleetManager.Application.Interfaces.Repositories;
using Laroche.FleetManager.Infrastructure.Persistence;
namespace Laroche.FleetManager.Infrastructure.Repositories
{
    public class VehiculesRepository(FleetManagerDbContext dbContext) :
     BaseRepository<Domain.Entities.Vehicule>(dbContext), IVehiculesRepository
    {
    }
}
