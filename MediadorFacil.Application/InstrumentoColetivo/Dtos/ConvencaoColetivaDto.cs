using MediadorFacil.Domain.InstrumentoColetivo.Enums;

namespace MediadorFacil.Application.InstrumentoColetivo.Dtos
{
    public class ConvencaoColetivaDto
    {
        public Guid? Id { get; set; }
        public string NumeroRegistro { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroSolicitacao { get; set; }
        public string NomeSindicatoTrabalhador { get; set; }
        public string NomeSindicatoPatronal { get; set; }
        public TipoSindicatoEnum TipoSindicato { get; set; }
        public ICollection<VigenciaDto> Vigencias { get; set; }        
        public SindicatoDto Sindicato { get; set; }
    }    
}
