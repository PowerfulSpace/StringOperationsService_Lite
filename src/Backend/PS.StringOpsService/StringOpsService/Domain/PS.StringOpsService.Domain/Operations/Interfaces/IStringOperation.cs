using PS.StringOpsService.Domain.Contexts;

namespace PS.StringOpsService.Domain.Operations.Interfaces
{
    public interface IStringOperation
    {
        public ProcessContext Apply(ProcessContext context);
    }
}
