using PS.StringOpsService.Application.Registrations;
using PS.StringOpsService.Domain.Operations.Interfaces;
using PS.StringOpsService.Infrastructure.Operations;

namespace PS.StringOpsService.Infrastructure.Registrations
{
    public class UpperOperationRegistration : IOperationRegistration
    {
        public IStringOperation Create(string[] args)
        {
            return new UpperOperation();
        }
    }
}
