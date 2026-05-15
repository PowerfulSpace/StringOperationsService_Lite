using PS.StringOpsService.Application.Delegates;
using PS.StringOpsService.Domain.Contexts;

namespace PS.StringOpsService.Application.Middleware.Interfaces
{
    public interface IProcessMiddleware
    {
        public ProcessContext Invoke(ProcessContext context, ProcessDelegate next);
    }
}
