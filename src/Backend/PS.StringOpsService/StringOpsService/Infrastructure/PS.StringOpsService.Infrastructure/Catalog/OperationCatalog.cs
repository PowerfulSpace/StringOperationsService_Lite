using PS.StringOpsService.Application.Catalog;
using PS.StringOpsService.Application.Registrations;

namespace PS.StringOpsService.Infrastructure.Catalog
{
    public class OperationCatalog : IOperationCatalog
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
