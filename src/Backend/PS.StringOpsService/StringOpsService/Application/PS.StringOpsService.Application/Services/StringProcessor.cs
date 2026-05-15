using PS.StringOpsService.Domain.Contexts;
using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Application.Services
{
    public class StringProcessor
    {
        public ProcessContext Process(ProcessContext context, IEnumerable<IStringOperation> operations)
        {
            foreach (var operation in operations)
            {
                context = operation.Apply(context);
            }

            return context;
        }
    }
}
