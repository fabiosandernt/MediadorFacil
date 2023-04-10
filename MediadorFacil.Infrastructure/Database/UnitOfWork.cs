using MediadorFacil.Domain.SeedWorks;
using MediadorFacil.Infrastructure.Context;

namespace MediadorFacil.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MediadorFacilContext _datacontext;
        public UnitOfWork(MediadorFacilContext dataContext)
        {
            _datacontext = dataContext;
        }
        public async Task<bool> CommitAsync()
        {
            return await _datacontext.SaveChangesAsync() > 0;
        }
    }
}

