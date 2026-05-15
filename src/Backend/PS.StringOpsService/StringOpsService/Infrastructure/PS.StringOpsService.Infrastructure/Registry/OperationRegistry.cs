using PS.StringOpsService.Application.Registrations.Interfaces;
using PS.StringOpsService.Application.Registry.Interfaces;

namespace PS.StringOpsService.Infrastructure.Registry
{
    public class OperationRegistry : IOperationRegistry
    {
        private readonly Dictionary<string, IOperationRegistration> _operations = new();

        public void Add(string operationStr, IOperationRegistration operation)
        {
            _operations.Add(operationStr, operation);
        }

        public IOperationRegistration Get(string key)
        {
            if (!_operations.TryGetValue(key, out var value))
            {
                throw new KeyNotFoundException();
            }

            return value;
        }
    }
}
