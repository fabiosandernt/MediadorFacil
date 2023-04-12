using MediadorFacil.Domain.InstrumentoColetivo.Enums;
using MediadorFacil.Domain.InstrumentoColetivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediadorFacil.Application.InstrumentoColetivo.Dtos
{
    public class SindicatoDto
    {
        public Guid? Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public TipoSindicatoEnum? TipoSindicato { get; set; }
    }
}
