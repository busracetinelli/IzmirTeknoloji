using MediatR;

namespace IzmirTeknoloji.Application.Features.TransactionHistory.Commands
{
    public class CreateTransactionHistoryCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; } 
        public string InputNumbers { get; set; } = string.Empty;
        public int Result { get; set; }
    }
}
