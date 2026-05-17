using PS.StringOpsService.Application.Descriptors;
using PS.StringOpsService.Application.OperationCatalog;

namespace PS.StringOpsService.Infrastructure.OperationCatalog
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
