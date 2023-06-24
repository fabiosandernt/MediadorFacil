using MediadorFacil.Domain.InstrumentoColetivo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediadorFacil.Infrastructure.Mapping
{
    public class ConvencaoColetivaMapping : IEntityTypeConfiguration<ConvencaoColetiva>
    {
        public void Configure(EntityTypeBuilder<ConvencaoColetiva> builder)
        {
            builder.ToTable("ConvencoesColetivas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NumeroRegistro)
                .HasColumnName("NumeroRegistro")
                .IsRequired();

            builder.Property(x => x.NumeroProcesso)
                 .HasColumnName("NumeroProcesso")
                .IsRequired();

            builder.Property(x => x.NumeroSolicitacao)
                .HasColumnName("NumeroSolicitacao")
                .IsRequired();

            builder.Property(x => x.NomeSindicatoTrabalhador)
               .HasColumnName("NomeSindicatoTrabalhador")
               .IsRequired();

            builder.Property(x => x.NomeSindicatoPatronal)
               .HasColumnName("NomeSindicatoPatronal")
               .IsRequired();

            builder.Property(x => x.TipoInstrumentoColetivo)
               .HasColumnName("TipoInstrumentoColetivo")
               .IsRequired(false);

            builder.HasOne(x => x.Vigencia)
                .WithOne(x => x.ConvencaoColetiva)
                .HasForeignKey<Vigencia>(x => x.ConvencaoColetivaId);
        }
    }
}
