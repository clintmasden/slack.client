using Newtonsoft.Json;

namespace Slack.Client.Models
{
    public class Message
    {
        public string Text { get; set; }

        public string User { get; set; }

        public string Username { get; set; }

        public string Type { get; set; }

        public string Subtype { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }
    }
}