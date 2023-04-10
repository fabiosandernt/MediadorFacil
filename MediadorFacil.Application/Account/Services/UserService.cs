using AutoMapper;
using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Domain.AccountAggregate;
using MediadorFacil.Domain.AccountAggregate.Repository;

namespace MediadorFacil.Application.Account.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        //private readonly IJwtService _jwtService;
        public UserService()
        {
        }
        public UserService(IUserRepository userRepository, IMapper mapper /*,IJwtService jwtService*/)
        {
            _userRepository = userRepository;
            _mapper = mapper;
           //_jwtService = jwtService;
        }

        public async Task<UserDto> Create(UserDto dto)
        {
            if (await _userRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var user = this._mapper.Map<User>(dto);
            user.Id = Guid.NewGuid();

            await _userRepository.AddAsync(user);

            return this._mapper.Map<UserDto>(user);

        }

        public async Task<UserDto> Delete(UserDto dto)
        {
            var user = this._mapper.Map<User>(dto);

            await this._userRepository.RemoveAsync(user);

            return this._mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var user = await this._userRepository.GetAllAsync();
            return this._mapper.Map<List<UserDto>>(user);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return this._mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Update(UserDto dto)
        {
            if (!dto.Id.HasValue) throw new Exception("Usuário não encontrado");

            if (await _userRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor && x.Id != dto.Id))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var user = await _userRepository.GetbyExpressionAsync(x => x.Id == dto.Id.Value);

            if (user is null) throw new Exception("Usuário não encontrado");

            user.Update(dto.Name, dto.Email, dto.Password, dto.UserType);

            await this._userRepository.UpdateAsync(user);

            return this._mapper.Map<UserDto>(user);
        }
    }
}
