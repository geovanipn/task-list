using Newtonsoft.Json;

namespace TaskList.Domain.SharedContext.OutputModels
{
    public sealed class ErrorApiResponse
    {
        [JsonProperty("success")]
        public bool Success => false;

        [JsonProperty("errors")]
        public string[] Errors { get; }

        public ErrorApiResponse(in string[] errors)
        {
            Errors = errors;
        }
    }
}
