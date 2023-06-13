using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.InstrumentoColetivo
{
    public class Vigencia : Entity<Guid>
    {
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public Guid ConvencaoColetivaId { get; set; }
        public virtual ConvencaoColetiva ConvencaoColetiva { get; set; }

        //EF
        protected Vigencia()
        {

        }
    }
}
