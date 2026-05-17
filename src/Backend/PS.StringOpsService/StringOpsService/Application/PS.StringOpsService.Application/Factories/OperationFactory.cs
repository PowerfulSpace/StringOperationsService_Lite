using PS.StringOpsService.Application.Descriptors;
using PS.StringOpsService.Application.OperationCatalog;
using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Application.Factories
{
    public class OperationFactory
    {
        private readonly IOperationCatalog catalog;

        public OperationFactory(IOperationCatalog repository)
        {
            this.catalog = repository;
        }
        public IStringOperation Create(string input)
        {
            var parts = input.Split(':');
            var name = parts[0];
            var args = parts.Length > 1
                ? parts[1].Split(',')
                : Array.Empty<string>();

            IOperationDescriptor registration = catalog.Get(name);

            IStringOperation result = registration.Create(args);
            return result;
        }
    }
}
