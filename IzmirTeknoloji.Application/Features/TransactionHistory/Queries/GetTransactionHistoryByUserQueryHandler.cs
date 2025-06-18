using System.Security.Claims;
using IzmirTeknoloji.Application.Dtos.TransactionHistory;
using IzmirTeknoloji.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Application.Features.TransactionHistory.Queries
{
    public class GetTransactionHistoryByUserQueryHandler : IRequestHandler<GetTransactionHistoryByUserQuery, List<TransactionHistoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTransactionHistoryByUserQueryHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TransactionHistoryDto>> Handle(GetTransactionHistoryByUserQuery request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı veya oturum açılmamış.");

            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı.");

            var userId = Guid.Parse(userIdClaim);

            // TransactionHistory is filtered by UserId
            var transaction = await _context.TransactionHistories.Where(x => x.UserId == userId).OrderByDescending(x => x.Date).ToListAsync(cancellationToken);

            var result = transaction.Select(x => new TransactionHistoryDto
            {
                Id = x.Id,
                UserId = x.UserId,
                InputNumbers = x.InputNumbers,
                Result = x.Result,
                Date = x.Date
            }).ToList();

            return result;
        }

    }
}
