using PS.StringOpsService.Application.Catalog;
using PS.StringOpsService.Application.Registrations;
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

            IOperationRegistration registration = catalog.Get(name);

            var result = registration.Create(args);
            return result;
        }
    }
}
