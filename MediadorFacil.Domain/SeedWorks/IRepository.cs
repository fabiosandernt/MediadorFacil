
using System.Linq.Expressions;

namespace MediadorFacil.Domain.SeedWorks
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(int page, int pageSize);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, object>> orderBy, bool ascending);
        Task<ICollection<T>> ExecuteQueryAsync(string query, params object[] parameters);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);
     

    }
}
