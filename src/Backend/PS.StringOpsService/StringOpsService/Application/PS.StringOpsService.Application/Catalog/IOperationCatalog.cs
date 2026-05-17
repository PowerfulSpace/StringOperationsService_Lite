using PS.StringOpsService.Application.Descriptors;

namespace PS.StringOpsService.Application.Catalog
{
    public interface IOperationCatalog
    {
        public IOperationDescriptor Get(string name);
        public void Add(string name, IOperationDescriptor operation);
    }
}
