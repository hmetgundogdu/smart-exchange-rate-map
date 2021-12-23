using MediatR;
using SmartExchangeRateMap.Application.Commands;
using SmartExchangeRateMap.Application.Core.Dtos;
using SmartExchangeRateMap.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.Handlers
{
    public class TestHandler : IRequestHandler<TestCommand, Response<TestDto>>
    {

        public  Task<Response<TestDto>> Handle(TestCommand request, CancellationToken cancellationToken)
        {

            //--restsharp sorgusunu burada yap

            return Task.FromResult(Response<TestDto>.Success(new TestDto() {
               X="Merhaba Dünya"
            }, 200));
        }
    }
}
