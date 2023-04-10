using MediadorFacil.Domain.AccountAggregate;
using Microsoft.EntityFrameworkCore;

namespace MediadorFacil.Infrastructure.Context
{
    public class MediadorFacilContext : DbContext
    {
        public MediadorFacilContext(DbContextOptions<MediadorFacilContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
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
