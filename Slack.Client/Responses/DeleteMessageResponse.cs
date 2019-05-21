using Newtonsoft.Json;

namespace Slack.Client.Responses
{
    public class DeleteMessageResponse : BaseResponse
    {
        [JsonProperty("Ts")]
        public string Timestamp { get; set; }

        public string Channel { get; set; }
    }
}