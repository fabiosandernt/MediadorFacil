﻿using MediadorFacil.Domain.InstrumentoColetivo.Enums;

namespace MediadorFacil.Application.InstrumentoColetivo.Dtos
{
    public class ConvencaoColetivaDto
    {
        public string NumeroRegistro { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroSolicitacao { get; set; }
        public string TipoInstrumentoColetivo { get; set; }
        public VigenciaDto vigenciaDto { get; set; }
        public string NomeSindicatoTrabalhador { get; set; }
        public string NomeSindicatoPatronal { get; set; }
        
    }
}
