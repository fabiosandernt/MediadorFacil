
namespace MediadorFacil.Domain.AccountAggregate.ValueObjects
{
    public class Email
    {
        private readonly string _valor;

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O valor do e-mail não pode ser nulo ou em branco.", nameof(email));
            }

            if (!IsValidEmail(email))
            {
                throw new ArgumentException("O valor do e-mail não é válido.", nameof(email));
            }

            _valor = email;
        }

        public string Valor => _valor;

        public override string ToString()
        {
            return _valor;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
