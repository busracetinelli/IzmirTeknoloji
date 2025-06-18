using IzmirTeknoloji.Application.Dtos.TransactionHistory;
using MediatR;

namespace IzmirTeknoloji.Application.Features.TransactionHistory.Queries
{
    public class GetTransactionHistoryByUserQuery : IRequest<List<TransactionHistoryDto>>
    {
        public Guid UserId { get; set; }
    }
}
