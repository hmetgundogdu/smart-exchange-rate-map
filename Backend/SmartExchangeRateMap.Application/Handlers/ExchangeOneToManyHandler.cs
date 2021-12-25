using MediatR;
using SmartExchangeRateMap.Application.Commands;
using SmartExchangeRateMap.Application.Core.Dtos;
using SmartExchangeRateMap.Application.Dtos;
using SmartExchangeRateMap.Application.OurService.Interface;
using SmartExchangeRateMap.Application.OurService.Models;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.Handlers
{
    public class ExchangeOneToManyHandler : IRequestHandler<ExchangeOneToManyCommand, Response<ExchangeOneToManyDto>>
    {
        private readonly IExchangeCurrencyOurService<FreeCurrencyApiResult> _exchangeCurrencyOurService;

        public ExchangeOneToManyHandler(IExchangeCurrencyOurService<FreeCurrencyApiResult> exchangeCurrencyOurService)
        {
            _exchangeCurrencyOurService = exchangeCurrencyOurService;
        }

        public async Task<Response<ExchangeOneToManyDto>> Handle(ExchangeOneToManyCommand request, CancellationToken cancellationToken)
        {
            var response = await _exchangeCurrencyOurService.ExchangeOneToManyAsync(request.BaseUnit);
            ExchangeOneToManyDto dto = response.Item1;
            HttpStatusCode statusCode = response.Item2;

            if (statusCode!=HttpStatusCode.OK)
            {
                return Response<ExchangeOneToManyDto>
                    .Fail($"Dış servisLe bağlantı sağlanamadı ourServiceStatusCode:{(int)statusCode}",500);
            }
            return Response<ExchangeOneToManyDto>.Success(dto,200);

        }
    }
}
