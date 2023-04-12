using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;
using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;

namespace MediadorFacil.Infrastructure.Repositories
{
    public class ConvencaoColetivaRepository : Repository<ConvencaoColetiva>, IConvencaoColetivaRepository
    {
        public ConvencaoColetivaRepository(MediadorFacilContext context) : base(context)
        {
           
        }      
                       
    }
}
