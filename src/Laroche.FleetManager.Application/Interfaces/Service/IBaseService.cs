using Laroche.FleetManager.Domain.BaseObjects;
using System.Linq.Expressions;

namespace Laroche.FleetManager.Application.Interfaces.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="predicat">The predicat.</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicat);
    }
}
