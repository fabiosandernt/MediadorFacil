using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;
using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;


namespace MediadorFacil.Infrastructure.Repositories
{
    public class ConvencaoColetivaRepository : Repository<ConvencaoColetiva>, IConvencaoColetivaRepository
    {
        public ConvencaoColetivaRepository(MediadorFacilContext context) : base(context)
        {
           
        }      
                       
    }
}
