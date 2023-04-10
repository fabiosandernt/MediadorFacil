using FluentValidation;
using MediadorFacil.Domain.AccountAggregate.Enums;
using MediadorFacil.Domain.AccountAggregate.Rules;
using MediadorFacil.Domain.AccountAggregate.ValueObjects;
using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.AccountAggregate
{
    public class User : Entity<Guid>
    {
        public string Name { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public UserTypeEnum UserType { get; set; }

        private readonly ISecurityUtils _securityUtils;
        public User(ISecurityUtils securityUtils)
        {
            _securityUtils = securityUtils;
        }

        public void SetPassword()
        {
            this.Password.Valor = _securityUtils.Hash(this.Password.Valor);
        }
             
        public void Validate() =>
            new UserValidator().ValidateAndThrow(this);

        public void Update(string name, Email email, Password password, UserTypeEnum userType)
        {
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
        }

    }   

}
