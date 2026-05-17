using PS.StringOpsService.Application.Middleware.Delegates;
using PS.StringOpsService.Application.Middleware.Interfaces;
using PS.StringOpsService.Domain.Contexts;

namespace PS.StringOpsService.Application.Middleware
{
    public class LoggingMiddleware : IProcessMiddleware
    {
        public ProcessContext Invoke(ProcessContext context, ProcessDelegate next)
        {
            Console.WriteLine($"Before: {context.Value}");

            var result = next(context);

            Console.WriteLine($"After: {result.Value}");

            return result;
        }
    }
}
