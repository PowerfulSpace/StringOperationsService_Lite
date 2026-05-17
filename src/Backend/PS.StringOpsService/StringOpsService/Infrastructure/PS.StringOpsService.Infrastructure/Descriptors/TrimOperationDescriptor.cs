using PS.StringOpsService.Application.Descriptors;
using PS.StringOpsService.Domain.Operations.Interfaces;
using PS.StringOpsService.Infrastructure.Operations;

namespace PS.StringOpsService.Infrastructure.Descriptors
{
    public class TrimOperationDescriptor : IOperationDescriptor
    {
        public IStringOperation Create(string[] args)
        {
            return new TrimOperation();
        }
    }
}
