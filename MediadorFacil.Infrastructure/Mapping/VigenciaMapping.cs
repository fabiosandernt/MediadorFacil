using MediadorFacil.Domain.InstrumentoColetivo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediadorFacil.Infrastructure.Mapping
{
    public class VigenciaMapping : IEntityTypeConfiguration<Vigencia>
    {
        public void Configure(EntityTypeBuilder<Vigencia> builder)
        {
            builder.ToTable("Vigencias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DataInicio).HasColumnName("DataInicio");
            builder.Property(x => x.DataFim).HasColumnName("DataFim");

        }
    }
}
