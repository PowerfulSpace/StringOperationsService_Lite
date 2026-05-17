using PS.StringOpsService.Application.Middleware.Delegates;
using PS.StringOpsService.Application.Middleware.Interfaces;
using PS.StringOpsService.Domain.Contexts;
using System.Diagnostics;

namespace PS.StringOpsService.Application.Middleware
{
    public class TimingMiddleware : IProcessMiddleware
    {
        public ProcessContext Invoke(ProcessContext context, ProcessDelegate next)
        {
            var sw = Stopwatch.StartNew();

            var result = next(context);

            sw.Stop();

            Console.WriteLine($"Executed in {sw.ElapsedMilliseconds}ms");

            return result;
        }
    }
}
