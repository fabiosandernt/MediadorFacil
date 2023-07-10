

using MediadorFacil.Domain.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MediadorFacil.Infrastructure.Mapping
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Cnpj);
            builder.Property(x => x.RazaoSocial);

            builder.HasMany(x => x.Sindicatos)
                .WithMany(x => x.Empresas);
        }
    }
}


