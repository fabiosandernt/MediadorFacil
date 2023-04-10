
using MediadorFacil.Application.Account.Dtos;

namespace MediadorFacil.Application.Account.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto dto);
        Task<List<UserDto>> GetAll();
        Task<UserDto> Update(UserDto dto);
        Task<UserDto> Delete(UserDto dto);
        Task<UserDto> GetById(Guid id);

        //Task<string> ObterTokenJwtAsync(LoginDto dto);
    }
}
