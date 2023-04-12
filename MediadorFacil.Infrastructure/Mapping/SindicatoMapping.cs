using MediadorFacil.Domain.InstrumentoColetivo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediadorFacil.Infrastructure.Mapping
{
    public class SindicatoMapping : IEntityTypeConfiguration<Sindicato>
    {
        public void Configure(EntityTypeBuilder<Sindicato> builder)
        {
            builder.ToTable("Sindicatos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RazaoSocial).HasColumnName("RazaoSocial");
            builder.Property(x => x.Cnpj).HasColumnName("Cnpj");
            builder.Property(x => x.TipoSindicato).HasColumnName("TipoSindicato");
          
        }
    }
}
