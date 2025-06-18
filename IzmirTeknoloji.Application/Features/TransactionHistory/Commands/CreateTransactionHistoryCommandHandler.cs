using System.Security.Claims;
using IzmirTeknoloji.Application.Features.TransactionHistory.Commands;
using IzmirTeknoloji.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IzmirTeknoloji.Application.Features.TransactionHistory.Handlers
{
    public class CreateTransactionHistoryCommandHandler : IRequestHandler<CreateTransactionHistoryCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTransactionHistoryCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(CreateTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı.");

            var inputNumbers = request.InputNumbers.Split(',')
                .Select(n => int.TryParse(n.Trim(), out var number) ? number : 0)
                .Where(n => n > 1)
                .ToList();

            var primeNumbers = inputNumbers.Where(IsPrime).ToList();
            var maxPrime = primeNumbers.Any() ? primeNumbers.Max() : 0;

            var transaction = new IzmirTeknoloji.Domain.Entities.TransactionHistory
            {
                UserId = Guid.Parse(userId),
                InputNumbers = request.InputNumbers,
                Result = maxPrime,
                Date = DateTime.UtcNow
            };

            _context.TransactionHistories.Add(transaction);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
