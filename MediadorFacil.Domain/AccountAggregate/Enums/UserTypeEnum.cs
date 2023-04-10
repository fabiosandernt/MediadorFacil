using System.ComponentModel;

namespace MediadorFacil.Domain.AccountAggregate.Enums
{
    public enum UserTypeEnum: int
    {
        [Description("Administrator")]
        Administrador = 1,        

        [Description("Analist")]
        Cliente = 2,

        [Description("Client")]
        Clinica = 3,
    }
}
