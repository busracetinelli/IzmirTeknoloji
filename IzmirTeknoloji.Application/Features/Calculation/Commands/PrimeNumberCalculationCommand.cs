using IzmirTeknoloji.Application.Dtos.Calculation;
using MediatR;

namespace IzmirTeknoloji.Application.Features.Calculation.Commands
{
    public class PrimeNumberCalculationCommand : IRequest<PrimeNumberCalculationResponse>
    {
        public string InputNumbers { get; set; }
    }
}
