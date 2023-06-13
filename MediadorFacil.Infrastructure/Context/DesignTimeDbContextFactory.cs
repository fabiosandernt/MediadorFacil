using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediadorFacil.Infrastructure.Context
{
    public  class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MediadorFacilContext>
    {
        public MediadorFacilContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<MediadorFacilContext>()
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<MediadorFacilContext>();
            var connectionString = 
                config.GetConnectionString("MediadorFacilApi");
            builder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);
            return new MediadorFacilContext(builder.Options);
        }
    }
}
