
namespace MediadorFacil.Domain.Account.ValueObjects
{

    public class Password
    {
        public Password()
        {

        }
        public Password(string valor)
        {
            this.Valor = valor ?? throw new ArgumentNullException(nameof(Password));
        }

        public string Valor { get; set; }
    }


}
