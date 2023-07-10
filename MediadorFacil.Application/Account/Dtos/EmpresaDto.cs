using MediadorFacil.Application.InstrumentoColetivo.Dtos;

namespace MediadorFacil.Application.Account.Dtos
{
    public class EmpresaDto
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public Guid UserId { get; set; }
        public ICollection<SindicatoDto> Sindicatos { get; set; }
    }
}
