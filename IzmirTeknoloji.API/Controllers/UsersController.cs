using IzmirTeknoloji.Application.Features.TransactionHistory.Queries;
using IzmirTeknoloji.Application.Features.Users.Commands.CreateUser;
using IzmirTeknoloji.Application.Features.Users.Queries;
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
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById()
        {
            var result = await _mediator.Send(new GetUserQuery());
            return Ok(result);
        }

    }
}
