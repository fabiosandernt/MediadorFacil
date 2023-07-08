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
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _convencaoColetivaService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/paginado")]
        public async Task<IActionResult> GetAllAsync([FromQuery]int page, int pageSize)
        {
            try
            {
                var result = await _convencaoColetivaService.GetAllAsync(page, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
