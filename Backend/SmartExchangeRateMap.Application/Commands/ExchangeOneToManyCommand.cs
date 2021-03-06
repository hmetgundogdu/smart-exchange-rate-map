using MediatR;
using SmartExchangeRateMap.Application.Core.Dtos;
using SmartExchangeRateMap.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.Commands
{
    public class ExchangeOneToManyCommand : IRequest<Response<ExchangeOneToManyDto>>
    {
        public string BaseUnit { get; set; } = "TRY";
    }
}
