using MediatR;

namespace MediadorFacil.Application.Account.Dtos
{
    public class LoginDto : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
        
}
