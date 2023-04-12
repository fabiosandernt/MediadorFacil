
using System.Linq.Expressions;

namespace MediadorFacil.Domain.SeedWorks
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<ICollection<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);       
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);        
        Task RemoveAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> GetbyExpressionAsync(Expression<Func<T, bool>> expression);

    }
}
