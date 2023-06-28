using MediadorFacil.Domain.SeedWorks;
using MediadorFacil.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediadorFacil.Infrastructure.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(MediadorFacilContext context)
        {
            this.Context = context;
            this.Query = Context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await this.Query.AddAsync(entity);
            //await this.Context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.Query.Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.Query.Update(entity); 
            await this.Context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return this.Query.AnyAsync(expression);
        }

        public async Task<T> GetbyExpressionAsync(Expression<Func<T, bool>> expression)
        {
            
            return await this.Query.FirstOrDefaultAsync(expression);
        }
               
    }
}
