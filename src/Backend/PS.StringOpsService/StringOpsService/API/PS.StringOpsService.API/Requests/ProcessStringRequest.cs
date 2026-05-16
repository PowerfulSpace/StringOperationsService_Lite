namespace PS.StringOpsService.API.Requests
{
    public sealed class ProcessStringRequest
    {
        public string Input { get; set; } = string.Empty;

        public string[] Operations { get; set; } = [];
    }
}
