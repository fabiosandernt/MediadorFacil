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
        protected User(ISecurityUtils securityUtils)
        {
            _securityUtils = securityUtils;
        }

        //EF
        protected User()
        {
        }
        public void SetPassword()
        {
            this.Password.Valor = SecurityUtil.HashSHA1(this.Password.Valor);
        }
             
        public void Validate() =>
            new UserValidator().ValidateAndThrow(this);

        public void Update(string name, string email, string password, UserTypeEnum userType)
        {
            Name = name;
            Email.Valor = email;
            Password.Valor = password;
            UserType = userType;
        }

    }   

}
