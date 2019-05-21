using Newtonsoft.Json;
using System;

namespace Slack.Client.Models
{
    public class User
    {
        public string Id;

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public string Color { get; set; }

        public UserProfile Profile { get; set; }

        public bool IsSlackBot
        {
            get
            {
                return Id.Equals("USLACKBOT", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_owner")]
        public bool IsOwner { get; set; }

        [JsonProperty("is_primary_owner")]
        public bool IsPrimaryOwner { get; set; }

        [JsonProperty("is_restricted")]
        public bool IsRestricted { get; set; }

        [JsonProperty("is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }

        [JsonProperty("has_2fa")]
        public bool Has2Fa { get; set; }

        [JsonProperty("two_factor_type")]
        public string TwoFactorType { get; set; }

        [JsonProperty("has_files")]
        public bool HasFiles { get; set; }

        public string Presence { get; set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }

        public string Timezone { get; set; }

        [JsonProperty("tz_label")]
        public string TimezoneLabel { get; set; }

        [JsonProperty("tz_offset")]
        public int TimezoneOffset { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }
    }
}