using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Application.Descriptors
{
    public interface IOperationDescriptor
    {
        public IStringOperation Create(string[] args);
    }
}
