using Newtonsoft.Json;
using Slack.Client.Models;
using System.Collections.Generic;

namespace Slack.Client.Responses
{
    public class ChannelListResponse : BaseResponse
    {
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
    }
}