using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartExchangeRateMap.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhangeController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ExhangeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWorldAsync([FromQuery]TestCommand testCommand)
        {
            var response = await _mediator.Send(testCommand);
            return CreateActionResultInstance(response);
        }
    }
}
