using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Application.InstrumentoColetivo.Dtos;
using MediadorFacil.Domain.Account;
using MediadorFacil.Domain.InstrumentoColetivo;

namespace MediadorFacil.Application.Profile
{
    public class MediadorFacilProfile : AutoMapper.Profile
    {
        public MediadorFacilProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<ConvencaoColetiva, ConvencaoColetivaDto>();
            CreateMap<ConvencaoColetivaDto, ConvencaoColetiva>();

            CreateMap<Sindicato, SindicatoDto>();
            CreateMap<SindicatoDto, Sindicato>();

            CreateMap<Empresa, EmpresaDto>();
            CreateMap<EmpresaDto, Empresa>();

            CreateMap<Vigencia, VigenciaDto>();
            CreateMap<VigenciaDto, Vigencia>();           
        }
    }
}


