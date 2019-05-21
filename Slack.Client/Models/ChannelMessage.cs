using Newtonsoft.Json;

namespace Slack.Client.Models
{
    public class ChannelMessage
    {
        [JsonProperty("value")]
        public string Value;

        [JsonProperty("creator")]
        public string Creator;

        [JsonProperty("last_set")]
        public string LastSet;
    }
}