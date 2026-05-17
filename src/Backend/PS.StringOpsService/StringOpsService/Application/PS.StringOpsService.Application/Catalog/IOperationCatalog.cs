using PS.StringOpsService.Application.Registrations;

namespace PS.StringOpsService.Application.Catalog
{
    public interface IOperationCatalog
    {
        public IOperationRegistration Get(string name);
        public void Add(string name, IOperationRegistration operation);
    }
}
