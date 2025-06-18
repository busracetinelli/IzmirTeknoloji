using IzmirTeknoloji.Application.Features.TransactionHistory.Commands;
using IzmirTeknoloji.Application.Features.TransactionHistory.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IzmirTeknoloji.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // JWT zorunlu
    public class TransactionHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Token'dan kullanıcıyı alıp sadece ona ait transaction'ları getirir.
        /// </summary>
        [HttpGet("user")]
        public async Task<IActionResult> GetByUser()
        {
            var result = await _mediator.Send(new GetTransactionHistoryByUserQuery());
            return Ok(result);
        }

        /// <summary>
        /// Tüm transaction'ları getirir (sadece adminler için örnek).
        /// </summary>
        [HttpGet("all")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTransactionHistoryQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateTransactionHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
