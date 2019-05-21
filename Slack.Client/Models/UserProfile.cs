using Newtonsoft.Json;

namespace Slack.Client.Models
{
    public class UserProfile
    {
        [JsonProperty("first_name")]
        public string FirstName;

        [JsonProperty("last_name")]
        public string LastName;

        [JsonProperty("real_name")]
        public string RealName;

        public string Email;

        public string Skype;

        [JsonProperty("status_emoji")]
        public string StatusEmoji;

        [JsonProperty("status_text")]
        public string StatusText;

        public string phone;

        [JsonProperty("image_192")]
        public string ImageUrl;

        public override string ToString()
        {
            return RealName;
        }
    }
}