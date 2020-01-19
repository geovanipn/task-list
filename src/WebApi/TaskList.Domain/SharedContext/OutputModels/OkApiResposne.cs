using Newtonsoft.Json;

namespace TaskList.Domain.SharedContext.OutputModels
{
    public sealed class OkApiResponse
    {
        [JsonProperty("success")]
        public bool Success => true;


        [JsonProperty("data")]
        public object Data { get; }

        public OkApiResponse(in object data)
        {
            Data = data;
        }
    }
}
