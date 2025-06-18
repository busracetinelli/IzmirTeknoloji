using IzmirTeknoloji.Application.Dtos.TransactionHistory;
using MediatR;

namespace IzmirTeknoloji.Application.Features.TransactionHistory.Queries
{
    public class GetAllTransactionHistoryQuery : IRequest<List<TransactionHistoryDto>>
    {
    }
}
