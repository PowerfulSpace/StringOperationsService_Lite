using PS.StringOpsService.Application.Catalog;
using PS.StringOpsService.Application.Descriptors;

namespace PS.StringOpsService.Infrastructure.Catalog
{
    public class OperationCatalog : IOperationCatalog
    {
        private readonly Dictionary<string, IOperationDescriptor> _operations = new();

        public void Add(string operationStr, IOperationDescriptor operation)
        {
            _operations.Add(operationStr, operation);
        }

        public IOperationDescriptor Get(string key)
        {
            if (!_operations.TryGetValue(key, out var value))
            {
                throw new KeyNotFoundException();
            }

            return value;
        }
    }
}
