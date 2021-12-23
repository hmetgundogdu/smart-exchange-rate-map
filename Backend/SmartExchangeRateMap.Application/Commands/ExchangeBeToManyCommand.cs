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
    public class ExchangeBeToManyCommand : IRequest<Response<ExchangeBeToManyDto>>
    {
        public string BaseUnit { get; set; }
    }
}
