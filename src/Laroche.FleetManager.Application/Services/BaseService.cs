using Laroche.FleetManager.Application.Interfaces.Repositories;
using Laroche.FleetManager.Application.Interfaces.Service;
using Laroche.FleetManager.Domain.BaseObjects;
using System.Linq.Expressions;

namespace Laroche.FleetManager.Application.Services
{
    public abstract class BaseService<TRepository, TEntity>(TRepository repository) : IBaseService<TEntity>
           where TRepository : IBaseRepository<TEntity>
           where TEntity : BaseEntity
    {
        private readonly TRepository _repository = repository;

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            //await _repository.SaveChangesAsync(default);
            return entity;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await _repository.GetAllAsync(predicat);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
