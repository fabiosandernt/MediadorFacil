using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.InstrumentoColetivo.Repository
{
    public interface IConvencaoColetivaRepository : IRepository<ConvencaoColetiva>
    {
        Task<IEnumerable<ConvencaoColetiva>> GetAllWithInclude();
    }
}
