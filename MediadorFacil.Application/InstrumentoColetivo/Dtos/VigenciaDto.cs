
using MediadorFacil.Domain.InstrumentoColetivo;
using System.ComponentModel.DataAnnotations;

namespace MediadorFacil.Application.InstrumentoColetivo.Dtos
{
    public class VigenciaDto
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid ConvencaoColetivaId { get; set; }
    }
}
