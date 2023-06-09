﻿using MediadorFacil.Domain.Account.Repository;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;
using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;
using MediadorFacil.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MediadorFacil.Infrastructure
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MediadorFacilContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IConvencaoColetivaRepository, ConvencaoColetivaRepository>();
                      
            return services;
        }
    }
}
