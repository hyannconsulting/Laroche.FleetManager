using Laroche.FleetManager.Application.Interfaces.Repositories;
using Laroche.FleetManager.Infrastructure.Persistence;
namespace Laroche.FleetManager.Infrastructure.Repositories
{
    public class DriversRepository(FleetManagerDbContext dbContext) :
        BaseRepository<Domain.Entities.Conducteur>(dbContext), IDriversRepository
    {
    }
}
