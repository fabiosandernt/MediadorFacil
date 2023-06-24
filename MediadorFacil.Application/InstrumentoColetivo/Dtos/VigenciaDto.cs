
using MediadorFacil.Domain.InstrumentoColetivo;
using System.ComponentModel.DataAnnotations;

namespace MediadorFacil.Application.InstrumentoColetivo.Dtos
{
    public class VigenciaDto
    {        
        public DateTime DataInicio { get; set; } 
        public DateTime DataFim { get; set; }
        public Guid ConvencaoColetivaId { get; set; }
        public virtual ConvencaoColetivaDto ConvencaoColetivaDto { get; set; }
    }
}
