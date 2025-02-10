using Laroche.FleetManager.Application.Interfaces.Repositories;
using Laroche.FleetManager.Application.Interfaces.Service;

namespace Laroche.FleetManager.Application.Services
{
    public class DriversService(IDriversRepository repository) :
            BaseService<IDriversRepository, Domain.Entities.Conducteur>(repository), IDriversService
    {
        public async Task<Domain.Entities.Conducteur> AddAsync(string name, string surname, string licenseNumber, string licenseState, string licenseExpirationDate)
        {
            var driver = new Domain.Entities.Conducteur
            {
                Nom = name,
                Prenoms = surname,
                NumeroTelephone = licenseNumber,
                PermisConduire = licenseState,
                DateEmbauche = DateTime.UtcNow // Assuming the hire date is the current date
            };

            var result = await AddAsync(driver);
            await repository.SaveChangesAsync(default);

            return result;
        }
    }
}
