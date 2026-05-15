namespace PS.StringOpsService.Domain.Contexts
{
    public record ProcessContext(
         string Value,
         IReadOnlyDictionary<string, object>? Items = null
         );

}
