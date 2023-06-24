using MediadorFacil.Domain.SeedWorks;
using System.ComponentModel.DataAnnotations;

namespace MediadorFacil.Domain.InstrumentoColetivo
{
    public class Vigencia : Entity<Guid>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid ConvencaoColetivaId { get; set; }
        public virtual ConvencaoColetiva ConvencaoColetiva { get; set; }

        //EF
        protected Vigencia()
        {

        }
    }
}
