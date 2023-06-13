using AutoMapper;
using MediadorFacil.Application.InstrumentoColetivo.Dtos;
using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;

namespace MediadorFacil.Application.InstrumentoColetivo.Services
{
    public class ConvencaoColetivaService : IConvencaoColetivaService
    {
        private readonly IIntrumentoColetivoRepository _convencaoColetivaRepository;
        private readonly IMapper _mapper;

        public ConvencaoColetivaService(
            IIntrumentoColetivoRepository convencaoColetivaRepository,
            IMapper mapper)
        {
            _convencaoColetivaRepository = convencaoColetivaRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ConvencaoColetivaDto>> GetAll()
        {
            var query = await _convencaoColetivaRepository  
                .GetAllAsync(x=>x.Vigencia, x=>x.Sindicatos);

            return this._mapper.Map<List<ConvencaoColetivaDto>>(query);
        }

        public async Task<ConvencaoColetivaDto> Insert(ConvencaoColetivaDto dto)
        {
            
            if (await _convencaoColetivaRepository.AnyAsync(x => x.NumeroRegistro == dto.NumeroRegistro))
                throw new Exception("Já existe uma CCT cadastrado com o Nº de Registro");
           
            try
            {
                var convencaoColetiva = this._mapper.Map<ConvencaoColetiva>(dto); 
                convencaoColetiva.Id = Guid.NewGuid();
                
                await this._convencaoColetivaRepository.AddAsync(convencaoColetiva);

                return this._mapper.Map<ConvencaoColetivaDto>(convencaoColetiva);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<ConvencaoColetivaDto> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

      

        public Task<ConvencaoColetivaDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ConvencaoColetivaDto> Update(ConvencaoColetivaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
