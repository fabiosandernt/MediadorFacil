using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;
using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;

namespace MediadorFacil.Infrastructure.Repositories
{
    public class InstrumentoColetivoRepository : Repository<ConvencaoColetiva>, IIntrumentoColetivoRepository
    {
        public InstrumentoColetivoRepository(MediadorFacilContext context) : base(context)
        {
           
        }      
                       
    }
}
