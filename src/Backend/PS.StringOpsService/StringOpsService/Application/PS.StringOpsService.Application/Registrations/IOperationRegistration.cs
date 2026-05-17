using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Application.Registrations
{
    public interface IOperationRegistration
    {
        public IStringOperation Create(string[] args);
    }
}
