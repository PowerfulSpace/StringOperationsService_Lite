using PS.StringOpsService.Application.Middleware.Delegates;
using PS.StringOpsService.Domain.Contexts;

namespace PS.StringOpsService.Application.Middleware.Interfaces
{
    public interface IProcessMiddleware
    {
        public ProcessContext Invoke(ProcessContext context, ProcessDelegate next);
    }
}
