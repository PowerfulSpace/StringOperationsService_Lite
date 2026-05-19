using Microsoft.AspNetCore.Mvc;
using PS.StringOpsService.API.DTOs;
using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Middleware;
using PS.StringOpsService.Application.Middleware.Delegates;
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
        private readonly MiddlewarePipelineBuilder _pipeline;

        public StringOperationsController(
            StringProcessor processor,
            OperationFactory factory,
            MiddlewarePipelineBuilder pipeline)
        {
            _processor = processor;
            _factory = factory;
            _pipeline = pipeline;
        }

        [HttpPost("process")]
        public ActionResult<ProcessStringResponse> Process(ProcessStringRequest request)
        {
            var operations = request.Operations
           .Select(x => _factory.Create(x));

            var context = new ProcessContext(request.Input);

            ProcessDelegate terminal = ctx => _processor.Process(ctx, operations);

            var pipeline = _pipeline.Build(terminal);

            var result = pipeline(context);

            return Ok(new ProcessStringResponse
            {
                Result = result.Value
            });
        }
    }
}
