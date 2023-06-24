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
        public virtual Vigencia Vigencia { get; set; }      
        
        //EF
        protected ConvencaoColetiva()
        {

        }

    }
}
