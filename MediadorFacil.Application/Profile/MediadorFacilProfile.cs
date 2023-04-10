using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Domain.AccountAggregate;

namespace MediadorFacil.Application.Profile
{
    public class MediadorFacilProfile : AutoMapper.Profile
    {
        public MediadorFacilProfile()
        {
            CreateMap<User, UserDto>();            

        }
    }
}


