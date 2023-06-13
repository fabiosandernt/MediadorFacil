using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.InstrumentoColetivo;
using Microsoft.EntityFrameworkCore;

namespace MediadorFacil.Infrastructure.Context
{
    public class MediadorFacilContext : DbContext
    {
        public MediadorFacilContext(DbContextOptions<MediadorFacilContext> options) : base(options)
        {
        }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediadorFacilContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
