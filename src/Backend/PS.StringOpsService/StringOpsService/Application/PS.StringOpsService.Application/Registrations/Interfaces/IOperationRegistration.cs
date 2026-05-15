using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Application.Registrations.Interfaces
{
    public interface IOperationRegistration
    {
        public IStringOperation Create(string[] args);
    }
}
