using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;
using MediadorFacil.Infrastructure.Context;
using MediadorFacil.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MediadorFacil.Infrastructure.Repositories
{
    public class ConvencaoColetivaRepository : Repository<ConvencaoColetiva>, IConvencaoColetivaRepository
    {
        public ConvencaoColetivaRepository(MediadorFacilContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<ConvencaoColetiva>> GetAllWithInclude()
        {
            var query = await this.Query.Include(x=>x.Vigencias).ToListAsync();
            return query;
        }
    }
}
