using PS.StringOpsService.Application.Registrations.Interfaces;
using PS.StringOpsService.Domain.Operations.Interfaces;
using PS.StringOpsService.Infrastructure.Operations;

namespace PS.StringOpsService.Infrastructure.Registrations
{
    public class ReverseOperationRegistration : IOperationRegistration
    {
        public IStringOperation Create(string[] args)
        {
            return new ReverseOperation();
        }
    }
}
