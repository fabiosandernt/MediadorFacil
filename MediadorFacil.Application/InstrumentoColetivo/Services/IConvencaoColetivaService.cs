using MediadorFacil.Application.InstrumentoColetivo.Dtos;
using MediadorFacil.Domain.InstrumentoColetivo;

namespace MediadorFacil.Application.InstrumentoColetivo.Services
{
    public interface IConvencaoColetivaService
    {
        Task<ConvencaoColetivaDto> Insert(ConvencaoColetivaDto dto);
        Task<ICollection<ConvencaoColetivaDto>> GetAllAsync();
        Task<ConvencaoColetivaDto> Update(ConvencaoColetivaDto dto);
        Task<ConvencaoColetivaDto> Delete(Guid id);
        Task<ConvencaoColetivaDto> GetByIdAsync(Guid id);       
    }
}
