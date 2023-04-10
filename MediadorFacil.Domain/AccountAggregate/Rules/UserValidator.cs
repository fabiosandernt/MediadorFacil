﻿using FluentValidation;

namespace MediadorFacil.Domain.AccountAggregate.Rules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.Password).SetValidator(new PasswordValidator());

        }
    } 
}
