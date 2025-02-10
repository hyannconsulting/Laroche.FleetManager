using Laroche.FleetManager.Application.Interfaces.Repositories;
using Laroche.FleetManager.Infrastructure.Persistence;
namespace Laroche.FleetManager.Infrastructure.Repositories
{
    public class DeplacementsRepository(FleetManagerDbContext dbContext) :
     BaseRepository<Domain.Entities.Deplacement>(dbContext), IDeplacementsRepository
    {
    }
}
