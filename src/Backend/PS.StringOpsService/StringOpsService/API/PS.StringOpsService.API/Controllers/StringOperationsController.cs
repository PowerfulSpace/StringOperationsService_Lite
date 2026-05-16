using Microsoft.AspNetCore.Mvc;
using PS.StringOpsService.API.Requests;
using PS.StringOpsService.API.Responses;
using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Services;
using PS.StringOpsService.Domain.Contexts;

namespace PS.StringOpsService.API.Controllers
{
    [ApiController]
    [Route("api/string-operations")]
    public sealed class StringOperationsController : ControllerBase
    {
        private readonly StringProcessor _processor;
        private readonly OperationFactory _factory;

        public StringOperationsController(
            StringProcessor processor,
            OperationFactory factory)
        {
            _processor = processor;
            _factory = factory;
        }

        [HttpPost("process")]
        public ActionResult<ProcessStringResponse> Process(ProcessStringRequest request)
        {
            var operations = request.Operations
                .Select(x => _factory.Create(x));

            var context = new ProcessContext(request.Input);

            var result = _processor.Process(context, operations);

            return Ok(new ProcessStringResponse
            {
                Result = result.Value
            });
        }
    }
}
