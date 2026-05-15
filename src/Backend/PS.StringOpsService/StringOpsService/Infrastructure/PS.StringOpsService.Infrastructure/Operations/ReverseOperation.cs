using PS.StringOpsService.Domain.Contexts;
using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Infrastructure.Operations
{
    public class ReverseOperation : IStringOperation
    {
        public ProcessContext Apply(ProcessContext context)
        {
            var result = new string(context.Value.Reverse().ToArray());

            return context with { Value = result };
        }
    }
}
