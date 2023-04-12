using MediadorFacil.Application.Account.Dtos;
using MediadorFacil.Application.Account.Services;
using MediadorFacil.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MediadorFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;    
        public UserController(IUserService userService)
        {
            this.userService = userService;          
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = await this.userService.GetAll();
            return Ok(query);
        }

        [HttpGet("{id:guid}/ObterPorId")]
        public async Task<IActionResult> GetById ([FromRoute] Guid id)
        { 
            var query = await this.userService.GetById(id);
            
            if (query== null) return NotFound();
            
            return Ok(query);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] UserDto dto)
        {
            if (dto == null) return BadRequest("Objeto nulo");

            try
            {
                var user = await this.userService.Create(dto);
                return Created($"{user.Name}", user.Email.Valor);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UserDto dto) 
        { 
            if(dto == null) return BadRequest("Objeto vazio ou nulo");

            try
            {
                var query = await this.userService.Update(dto);
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == null) return BadRequest("Objeto vazio ou nulo");

            try
            {
                var query = await this.userService.Delete(id);
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        } 
    }
}
