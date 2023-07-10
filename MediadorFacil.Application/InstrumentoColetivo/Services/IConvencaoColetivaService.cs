using MediadorFacil.Application.InstrumentoColetivo.Dtos;
using MediadorFacil.Domain.InstrumentoColetivo;
using System.Linq.Expressions;

namespace MediadorFacil.Application.InstrumentoColetivo.Services
{
    public interface IConvencaoColetivaService
    {
        Task<ConvencaoColetivaDto> GetByIdAsync(Guid id);
        Task<ICollection<ConvencaoColetivaDto>> GetAllAsync();
        Task<ICollection<ConvencaoColetivaDto>> GetAllAsync(int page, int pageSize);
        Task<ICollection<ConvencaoColetivaDto>> GetAllAsync(Expression<Func<ConvencaoColetivaDto, object>> orderBy, bool ascending = true);
        Task<ICollection<ConvencaoColetivaDto>> ExecuteQueryAsync(string query, params object[] parameters);
        Task<ConvencaoColetivaDto> Create(ConvencaoColetivaDto dto);
        Task<ConvencaoColetivaDto> Update(ConvencaoColetivaDto dto);
        Task<ConvencaoColetivaDto> Delete(Guid id);
        Task<ConvencaoColetivaDto> GetByExpressionAsync(Expression<Func<ConvencaoColetivaDto, bool>> expression);
    }
}
