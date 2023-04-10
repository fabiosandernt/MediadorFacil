using MediadorFacil.Domain.AccountAggregate.Enums;
using MediadorFacil.Domain.AccountAggregate.ValueObjects;

namespace MediadorFacil.Application.Account.Dtos
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
