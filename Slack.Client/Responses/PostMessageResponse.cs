using Newtonsoft.Json;
using Slack.Client.Models;

namespace Slack.Client.Responses
{
    public class PostMessageResponse : BaseResponse
    {
        [JsonProperty("Ts")]
        public string Timestamp { get; set; }

        public string Channel { get; set; }

        public Message Message { get; set; }
    }
}