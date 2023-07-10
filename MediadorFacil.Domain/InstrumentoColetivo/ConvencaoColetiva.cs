using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.InstrumentoColetivo
{
    public class ConvencaoColetiva : Entity<Guid>
    {
        public string NumeroRegistro { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroSolicitacao { get; set; }
        public string NomeSindicatoTrabalhador { get; set; }
        public string NomeSindicatoPatronal { get; set; }
        public string TipoInstrumentoColetivo { get; set; }
        public List<Sindicato> Sindicatos { get; set; } = new List<Sindicato>();
        public List<Vigencia> Vigencias { get; set; } = new List<Vigencia>();
                
        //EF
        protected ConvencaoColetiva()
        {
            
        }

    }
}
