using Newtonsoft.Json;

namespace Slack.Client.Dtos
{
    public class DeleteMessageDto
    {
        public DeleteMessageDto()
        {
            AsUser = false;
        }

        [JsonProperty("channel")]
        public string ChannelId { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("as_user")]
        public bool AsUser { get; set; }
    }
}