using AutoMapper;
using MediadorFacil.Application.InstrumentoColetivo.Dtos;
using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.InstrumentoColetivo.Repository;
using System.Linq;
using System.Linq.Expressions;

namespace MediadorFacil.Application.InstrumentoColetivo.Services
{
    public class ConvencaoColetivaService : IConvencaoColetivaService
    {
        private readonly IConvencaoColetivaRepository _convencaoColetivaRepository;
        private readonly IMapper _mapper;

        public ConvencaoColetivaService(
            IConvencaoColetivaRepository convencaoColetivaRepository,
            IMapper mapper)
        {
            _convencaoColetivaRepository = convencaoColetivaRepository;
            _mapper = mapper;
        }
        public Task<ConvencaoColetivaDto> Create(ConvencaoColetivaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ConvencaoColetivaDto> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ConvencaoColetivaDto>> ExecuteQueryAsync(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ConvencaoColetivaDto>> GetAllAsync()
        {
            var query = await _convencaoColetivaRepository.GetAllAsync();
            var result  = _mapper.Map<List<ConvencaoColetivaDto>>(query);
            return result;
        }

        public async Task<ICollection<ConvencaoColetivaDto>> GetAllAsync(int page, int pageSize)
        {
            var query = await _convencaoColetivaRepository.GetAllAsync(page, pageSize);
            var result = _mapper.Map<ICollection<ConvencaoColetivaDto>>(query);
         
            foreach (var item in result)
            {
                item.UrlVisualizar = GenerateUrlVisualizar(item.NumeroSolicitacao);
            }
            return result;
        }

        public async Task<ICollection<ConvencaoColetivaDto>> GetAllAsync(Expression<Func<ConvencaoColetivaDto, object>> orderBy, bool ascending = true)
        {
            var orderByExpression = _mapper.Map<Expression<Func<ConvencaoColetiva, object>>>(orderBy);

            var query = await _convencaoColetivaRepository.GetAllAsync(orderByExpression, ascending);

            var result = _mapper.Map<ICollection<ConvencaoColetivaDto>>(query);

            return result;
        }


        public Task<ConvencaoColetivaDto> GetByExpressionAsync(Expression<Func<ConvencaoColetivaDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<ConvencaoColetivaDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ConvencaoColetivaDto> Update(ConvencaoColetivaDto dto)
        {
            throw new NotImplementedException();
        }

        private string GenerateUrlVisualizar(string numeroSolicitacao)
        {
            string urlBase = "http://www3.mte.gov.br/sistemas/mediador/Resumo/ResumoVisualizar?NrSolicitacao=";
            string url = urlBase + numeroSolicitacao;
            return url;
        }
    }
}
