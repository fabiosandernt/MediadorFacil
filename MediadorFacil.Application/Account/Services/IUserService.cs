
using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.SeedWorks;
using System.Linq.Expressions;

namespace MediadorFacil.Application.Account.Services
{
    public interface IUserService 
    { 
        Task<UserDto> Create(UserDto dto);
        Task<List<UserDto>> GetAll();
        Task<List<UserDto>> GetAll(int page, int pageSize);
        Task<List<UserDto>> GetAll(Expression<Func<User, object>> orderBy = null, bool ascending = true);
        Task<UserDto> Update(UserDto dto);
        Task<UserDto> Delete(Guid id);
        Task<UserDto> GetById(Guid id);
    }
}
