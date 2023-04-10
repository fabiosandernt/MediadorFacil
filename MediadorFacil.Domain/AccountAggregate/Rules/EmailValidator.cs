using FluentValidation;
using MediadorFacil.Domain.AccountAggregate.ValueObjects;
using System.Text.RegularExpressions;

namespace MediadorFacil.Domain.AccountAggregate.Rules
{
    public class EmailValidator : AbstractValidator<Email>
    {
        private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public EmailValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(BeAEmailValid).WithMessage("Email inválido");
        }
        private bool BeAEmailValid(string valor) => Regex.IsMatch(valor, Pattern);
    }
}
