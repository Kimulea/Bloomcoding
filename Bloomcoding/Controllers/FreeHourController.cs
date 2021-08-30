using Features.FreeHourFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.Controllers
{
    [Route("api")]
    [ApiController]
    public class FreeHourController : Controller
    {
        private readonly IMediator _mediator;

        public FreeHourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateFreeHour")]
        public async Task<IActionResult> RegisterUser(CreateFreeHourCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
