using MediadorFacil.Domain.InstrumentoColetivo.Enums;
using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.InstrumentoColetivo
{
    public class Sindicato : Entity<Guid>
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public TipoSindicatoEnum? TipoSindicato { get; set; }
        public Guid ConvencaoColetivaId { get; set; }
        public ConvencaoColetiva ConvencaoColetiva { get; set; }

        //EF
        protected Sindicato()
        {

        }
    }
}
