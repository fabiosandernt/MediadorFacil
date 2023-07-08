using MediadorFacil.Domain.SeedWorks;
using MediadorFacil.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediadorFacil.Infrastructure.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(MediadorFacilContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Query.AddAsync(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Query.ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(int page, int pageSize)
        {
           return await Query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, object>> orderBy, bool ascending = true)
        {
            IQueryable<T> query = Query;

            if (orderBy != null)
            {
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<ICollection<T>> ExecuteQueryAsync(string query, params object[] parameters)
        {
            return await Query.FromSqlRaw(query, parameters).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Query.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return Query.AnyAsync(expression);
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await Query.FirstOrDefaultAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await Query.CountAsync(expression);
        }

        public async Task<int> CountAsync()
        {
            return await Query.CountAsync();
        }

        public Task BeginTransactionAsync()
        {
            // Lógica de início da transação
            return Task.CompletedTask;
        }

        public async Task CommitTransactionAsync()
        {
            // Lógica de confirmação da transação
            await Context.SaveChangesAsync();
        }

        public Task RollbackTransactionAsync()
        {
            // Lógica de reversão da transação
            // Exemplo: Context.Dispose(); para descartar as alterações não confirmadas
            return Task.CompletedTask;
        }
    }
}
