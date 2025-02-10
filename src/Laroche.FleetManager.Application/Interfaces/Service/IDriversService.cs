namespace Laroche.FleetManager.Application.Interfaces.Service
{
    public interface IDriversService : IBaseService<Domain.Entities.Conducteur>
    {
        Task<Domain.Entities.Conducteur> AddAsync(string name, string surname, string licenseNumber, string licenseState, string licenseExpirationDate);
    }
}
