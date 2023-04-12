
using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Application.Account.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto dto);
        Task<List<UserDto>> GetAll();
        Task<UserDto> Update(UserDto dto);
        Task<UserDto> Delete(Guid id);
        Task<UserDto> GetById(Guid id);

        //Task<string> ObterTokenJwtAsync(LoginDto dto);
    }
}
