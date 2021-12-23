using MediatR;
using SmartExchangeRateMap.Application.Commands;
using SmartExchangeRateMap.Application.Core.Dtos;
using SmartExchangeRateMap.Application.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.Handlers
{
    public class ExchangeBeToManyHandler : IRequestHandler<ExchangeBeToManyCommand, Response<ExchangeBeToManyDto>>
    {

        public Task<Response<ExchangeBeToManyDto>> Handle(ExchangeBeToManyCommand request, CancellationToken cancellationToken)
        {

           
            return Task.FromResult(Response<TestDto>.Success(new TestDto()
            {
                X = "Merhaba Dünya"
            }, 200));
        }
    }
}
