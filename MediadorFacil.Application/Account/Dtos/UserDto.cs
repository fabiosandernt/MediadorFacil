using MediadorFacil.Domain.Account.Enums;
using MediadorFacil.Domain.Account.ValueObjects;

namespace MediadorFacil.Application.Account.Dtos
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public UserTypeEnum UserType { get; set; }
        public ICollection<EmpresaDto> Empresas { get; set; }
    }
}
