using AutoMapper;
using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.Account.Repository;
using MediadorFacil.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediadorFacil.Application.Account.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Create(UserDto dto)
        {
            if (await _userRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid();

            user.Validate();
            user.SetPassword();

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Delete(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            await _userRepository.RemoveAsync(user);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> GetAll(int page, int pageSize)
        {
            var users = await _userRepository.GetAllAsync(page, pageSize);
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> GetAll(Expression<Func<User, object>> orderBy = null, bool ascending = true)
        {
            var users = await _userRepository.GetAllAsync(orderBy, ascending);
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Update(UserDto dto)
        {
            if (!dto.Id.HasValue)
                throw new Exception("Usuário não encontrado");

            if (await _userRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor && x.Id != dto.Id))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var user = await _userRepository.GetByExpressionAsync(x => x.Id == dto.Id.Value);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            user.Update(dto.Name, dto.Email.Valor, dto.Password.Valor, dto.UserType);

            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
