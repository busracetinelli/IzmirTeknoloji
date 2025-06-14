using IzmirTeknoloji.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IzmirTeknoloji.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUser)
        {
            if (createUser == null)
            {
                return BadRequest("User Not Found.");
            }
            var userId = await _mediator.Send(createUser);
            return Ok(new { Id = userId });
            //return CreatedAtAction(nameof(CreateUser), new { id = userId }, null);
        }
    }
}
