using PS.StringOpsService.Application.Registrations.Interfaces;

namespace PS.StringOpsService.Application.Registry.Interfaces
{
    public interface IOperationRegistry
    {
        public IOperationRegistration Get(string name);
        public void Add(string name, IOperationRegistration operation);
    }
}
