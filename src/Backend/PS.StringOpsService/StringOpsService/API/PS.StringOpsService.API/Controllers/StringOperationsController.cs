using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.StringOpsService.API.DTOs;
using PS.StringOpsService.Application.CQRS.Commands.ProcessString;

namespace PS.StringOpsService.API.Controllers
{
    [ApiController]
    [Route("api/string-operations")]
    public sealed class StringOperationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StringOperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("process")]
        public async Task<ActionResult<ProcessStringResponse>> Process(ProcessStringRequest request)
        {
            var command = new ProcessStringCommand(request.Input, request.Operations);
            var result = await _mediator.Send(command);

            return Ok(new ProcessStringResponse { Result = result.Value });
        }
    }
}
