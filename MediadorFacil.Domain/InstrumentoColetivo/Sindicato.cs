using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.InstrumentoColetivo.Enums;
using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.InstrumentoColetivo
{
    public class Sindicato : Entity<Guid>
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public TipoSindicatoEnum? TipoSindicato { get; set; }
 
        public ICollection<Empresa> Empresas { get; set; }

        public ICollection<ConvencaoColetiva> ConvencaoColetivas { get; set; } = new List<ConvencaoColetiva>();
        //EF
        protected Sindicato()
        {

        }
    }
}
