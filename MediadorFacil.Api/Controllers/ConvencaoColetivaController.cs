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
        public async Task<IActionResult> Get()
        {
            var query = await _convencaoColetivaService.GetAll();
            return Ok(query);
        }
        [HttpPost()]
        public async Task<IActionResult> Insert([FromQuery] ConvencaoColetivaDto dto)
        {
            if (dto == null) return BadRequest("Objeto nulo");
            
            try
            {
                //Implementa lógica de inserção manual de convenções coletivas

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new ApiResponseError(e.Message)); ;
            }
        }

    }
}
