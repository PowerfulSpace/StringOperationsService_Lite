namespace PS.StringOpsService.API.DTOs
{
    public sealed class ProcessStringRequest
    {
        public string Input { get; set; } = string.Empty;

        public string[] Operations { get; set; } = [];
    }
}
