using Laroche.FleetManager.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Laroche.FleetManager.Infrastructure.Repositories
{
    public class BaseRepository<T>(DbContext dbContext) : IBaseRepository<T> where T : class
    {
        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext
               .Set<T>()
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
