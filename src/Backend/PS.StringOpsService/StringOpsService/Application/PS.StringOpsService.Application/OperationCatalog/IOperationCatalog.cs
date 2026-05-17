using PS.StringOpsService.Application.Descriptors;

namespace PS.StringOpsService.Application.OperationCatalog
{
    public interface IOperationCatalog
    {
        public IOperationDescriptor Get(string name);
        public void Add(string name, IOperationDescriptor operation);
    }
}
