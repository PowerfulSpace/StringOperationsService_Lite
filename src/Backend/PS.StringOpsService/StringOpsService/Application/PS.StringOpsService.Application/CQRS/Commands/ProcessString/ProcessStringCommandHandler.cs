using MediatR;
using PS.StringOpsService.Application.DTOs;
using PS.StringOpsService.Application.Factories;
using PS.StringOpsService.Application.Middleware;
using PS.StringOpsService.Application.Middleware.Delegates;
using PS.StringOpsService.Application.Services;
using PS.StringOpsService.Domain.Contexts;

namespace PS.StringOpsService.Application.CQRS.Commands.ProcessString
{
    public class ProcessStringCommandHandler : IRequestHandler<ProcessStringCommand, ProcessStringResult>
    {
        private readonly StringProcessor _processor;
        private readonly OperationFactory _factory;
        private readonly MiddlewarePipelineBuilder _pipeline;

        public ProcessStringCommandHandler(
            StringProcessor processor,
            OperationFactory factory,
            MiddlewarePipelineBuilder pipeline)
        {
            _processor = processor;
            _factory = factory;
            _pipeline = pipeline;
        }

        public Task<ProcessStringResult> Handle(ProcessStringCommand request, CancellationToken cancellationToken)
        {
            var ops = request.Operations.Select(x => _factory.Create(x));
            var context = new ProcessContext(request.Input);

            ProcessDelegate terminal = ctx => _processor.Process(ctx, ops);

            var pipeline = _pipeline.Build(terminal);
            var result = pipeline(context);

            return Task.FromResult(new ProcessStringResult(result.Value));
        }
    }
}
