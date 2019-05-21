using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.Client.Dtos
{
    public class PostMessageDto
    {
        public PostMessageDto()
        {
            AsUser = false;

            Attachements = null;

            IconUrl = default(string);

            LinkNames = true;

            UnfurlLinks = true;

            UnfurlMedia = false;

            BotName = default(string);
        }

        [JsonProperty("channel")]
        public string ChannelId { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("as_user")]
        public bool AsUser { get; set; }

        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        [JsonProperty("link_names")]
        public bool? LinkNames { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<AttachmentDto> Attachements { get; set; }

        [JsonProperty("unfurl_links")]
        public bool? UnfurlLinks { get; set; }

        [JsonProperty("unfurl_media")]
        public bool? UnfurlMedia { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string BotName { get; set; }
    }
}