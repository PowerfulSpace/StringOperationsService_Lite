using PS.StringOpsService.Application.Registry.Interfaces;
using PS.StringOpsService.Domain.Operations.Interfaces;

namespace PS.StringOpsService.Application.Factories
{
    public class OperationFactory
    {
        private readonly IOperationRegistry repository;

        public OperationFactory(IOperationRegistry repository)
        {
            this.repository = repository;
        }
        public IStringOperation Create(string input)
        {
            var parts = input.Split(':');
            var name = parts[0];
            var args = parts.Length > 1
                ? parts[1].Split(',')
                : Array.Empty<string>();

            var registration = repository.Get(name);

            var result = registration.Create(args);
            return result;
        }
    }
}
