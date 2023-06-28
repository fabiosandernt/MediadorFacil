using MediadorFacil.Application.InstrumentoColetivo.Dtos;
using MediadorFacil.Application.InstrumentoColetivo.Services;
using MediadorFacil.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MediadorFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ConvencaoColetivaController : ControllerBase
    {
        private readonly IConvencaoColetivaService _convencaoColetivaService;

        public ConvencaoColetivaController(IConvencaoColetivaService convencaoColetivaService)
        {
            _convencaoColetivaService = convencaoColetivaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = await _convencaoColetivaService.GetAllAsync();
            return Ok(query);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        //{
        //    ICollection<ConvencaoColetivaDto> query = await _convencaoColetivaService.GetAllAsync();

        //    // Aplicar paginação
        //    var totalCount = query.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        //    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        //    var result = new
        //    {
        //        TotalCount = totalCount,
        //        TotalPages = totalPages,
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        Data = query
        //    };

        //    return Ok(result);
        //}



        [HttpGet("{id:guid}/ObterPorId")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = await this._convencaoColetivaService.GetByIdAsync(id);
            if (query == null) return NotFound();
            return Ok(query);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromQuery] ConvencaoColetivaDto dto)
        {
            if (dto == null) return BadRequest("Objeto nulo");
            
            try
            {              
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new ApiResponseError(e.Message)); ;
            }
        }

    }
}
