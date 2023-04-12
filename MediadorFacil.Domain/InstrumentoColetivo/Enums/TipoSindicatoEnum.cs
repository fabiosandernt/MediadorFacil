using System.ComponentModel;

namespace MediadorFacil.Domain.InstrumentoColetivo.Enums
{
    public enum TipoSindicatoEnum : int
    {
        [Description("Trabalhador")]
        Administrador = 1,

        [Description("Patronal")]
        Cliente = 2,
       
    }
}
