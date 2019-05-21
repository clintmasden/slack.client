using Newtonsoft.Json;

namespace Slack.Client.Models
{
    public class Channel : Conversation
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("creator")]
        public string Creator;

        [JsonProperty("is_archived")]
        public bool IsArchived;

        [JsonProperty("is_member")]
        public bool IsMember;

        [JsonProperty("is_general")]
        public bool IsGeneral;

        [JsonProperty("is_channel")]
        public bool IsChannel;

        [JsonProperty("is_group")]
        public bool IsGroup;

        public bool IsPrivateGroup { get { return Id != null && Id[0] == 'G'; } }

        [JsonProperty("num_members")]
        public int MemberCount;

        [JsonProperty("topic")]
        public ChannelMessage Topic;

        [JsonProperty("purpose")]
        public ChannelMessage Purpose;

        [JsonProperty("members")]
        public string[] Members;
    }
}