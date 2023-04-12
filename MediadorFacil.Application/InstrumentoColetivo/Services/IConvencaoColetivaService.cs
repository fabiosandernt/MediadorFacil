using MediadorFacil.Application.InstrumentoColetivo.Dtos;

namespace MediadorFacil.Application.InstrumentoColetivo.Services
{
    public interface IConvencaoColetivaService
    {
        Task<ConvencaoColetivaDto> Insert(ConvencaoColetivaDto dto);
        Task<ICollection<ConvencaoColetivaDto>> GetAll();
        Task<ConvencaoColetivaDto> Update(ConvencaoColetivaDto dto);
        Task<ConvencaoColetivaDto> Delete(Guid id);
        Task<ConvencaoColetivaDto> GetById(Guid id);
    }
}
