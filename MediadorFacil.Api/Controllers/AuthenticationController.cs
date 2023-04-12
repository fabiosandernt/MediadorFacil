using MediadorFacil.Application.Account.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediadorFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] UserDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await _mediator.Send(dto);

                if (string.IsNullOrWhiteSpace((string?)result))
                    return Unauthorized("Usuário ou senha inválidos");

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
