using IzmirTeknoloji.Application.Features.Auth.Commands.LoginUser;
using IzmirTeknoloji.Application.Features.Auth.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IzmirTeknoloji.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand createUser)
        {
            if (createUser == null)
            {
                return BadRequest("Kullanıcı Bulunamadı.");
            }

            var userId = await _mediator.Send(createUser);
            return Ok(new { Id = userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("Giriş Bilgileri Eksik.");
            }

            var result = await _mediator.Send(loginUser);

            if (result == null)
            {
                return Unauthorized("Giriş bilgileri hatalı.");
            }

            return Ok(result); 
        }
    }
}
