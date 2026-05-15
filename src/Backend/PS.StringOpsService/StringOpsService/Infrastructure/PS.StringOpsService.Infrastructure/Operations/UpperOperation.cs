using PS.StringOpsService.Domain.Contexts;
using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Infrastructure.Operations
{
    public class UpperOperation : IStringOperation
    {
        public ProcessContext Apply(ProcessContext context)
        {
            var result = context.Value.ToUpper();

            return context with { Value = result };
        }
    }
}
