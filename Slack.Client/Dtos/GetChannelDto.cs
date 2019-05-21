using Newtonsoft.Json;

namespace Slack.Client.Dtos
{
    public class GetChannelDto
    {
        public GetChannelDto()
        {
            HasArchives = false;

            ReturnLimit = 1000;

            // public_channel, private_channel
            ChannelType = "public_channel";
        }

        [JsonProperty("exclude_archived")]
        public bool HasArchives { get; set; }

        [JsonProperty("limit")]
        public int ReturnLimit { get; set; }

        [JsonProperty("types")]
        public string ChannelType { get; set; }
    }
}