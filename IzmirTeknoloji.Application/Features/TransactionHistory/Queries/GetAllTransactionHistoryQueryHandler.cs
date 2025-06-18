using System.Security.Claims;
using IzmirTeknoloji.Application.Dtos.TransactionHistory;
using IzmirTeknoloji.Application.Features.TransactionHistory.Queries;
using IzmirTeknoloji.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Application.Features.TransactionHistory.Handlers
{
    public class GetAllTransactionHistoryQueryHandler : IRequestHandler<GetAllTransactionHistoryQuery, List<TransactionHistoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllTransactionHistoryQueryHandler(IApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContextAccessor = httpContext;
        }

        public async Task<List<TransactionHistoryDto>> Handle(GetAllTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null || !user.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı veya oturum açılmamış.");

            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            var userEmail = user.FindFirst(ClaimTypes.Email)?.Value;


            if (role == null || role != "1") 
                throw new UnauthorizedAccessException("Bu işlemi yalnızca admin kullanıcılar gerçekleştirebilir.");

            var transactions = await _context.TransactionHistories
                .Select(th => new TransactionHistoryDto
                {
                    Id = th.Id,
                    UserId = th.UserId,
                    Email = userEmail,
                    InputNumbers = th.InputNumbers,
                    Result = th.Result,
                    Date = th.Date
                }).OrderByDescending(x => x.Date).ToListAsync(cancellationToken);

            return transactions;
        }
    }
}
