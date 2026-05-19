using PS.StringOpsService.Application.Middleware.Delegates;
using PS.StringOpsService.Application.Middleware.Interfaces;

namespace PS.StringOpsService.Application.Middleware
{
    public class MiddlewarePipelineBuilder
    {
        private readonly IEnumerable<IProcessMiddleware> _middlewares;

        public MiddlewarePipelineBuilder(IEnumerable<IProcessMiddleware> middlewares)
        {
            _middlewares = middlewares;
        }

        public ProcessDelegate Build(ProcessDelegate terminal)
        {
            var pipeline = terminal;

            foreach (var middleware in _middlewares.Reverse())
            {
                var next = pipeline;

                pipeline = ctx => middleware.Invoke(ctx, next);
            }

            return pipeline;
        }
    }
}
