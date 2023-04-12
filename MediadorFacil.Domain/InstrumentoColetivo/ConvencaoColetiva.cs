using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.InstrumentoColetivo
{
    public class ConvencaoColetiva : Entity<Guid>
    {
        public string NumeroRegistro { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroSolicitacao { get; set; }
        public ICollection<Sindicato> Sindicatos { get; set; }
        public Vigencia Vigencia { get; set; }     
     
        //EF
        protected ConvencaoColetiva()
        {

        }

    }
}
