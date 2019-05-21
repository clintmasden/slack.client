using Newtonsoft.Json;

namespace Slack.Client.Models
{
    public class Conversation
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("created")]
        public string CreatedDate;

        [JsonProperty("last_read")]
        public string LastReadDate;

        [JsonProperty("is_open")]
        public bool IsOpen;

        [JsonProperty("is_starred")]
        public bool IsStarred;

        [JsonProperty("unread_count")]
        public int UnreadCount;

        [JsonProperty("latest")]
        public Message LatestMessage;
    }
}