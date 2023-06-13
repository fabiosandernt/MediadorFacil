
namespace MediadorFacil.Domain.Account.ValueObjects
{
    public class Email
    {

        public Email()
        {

        }

        public Email(string email)
        {
            Valor = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Valor { get; set; }

    }
}
