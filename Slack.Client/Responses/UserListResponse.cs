using Newtonsoft.Json;
using Slack.Client.Models;
using System.Collections.Generic;

namespace Slack.Client.Responses
{
    public class UserListResponse : BaseResponse
    {
        [JsonProperty("members")]
        public List<User> Users { get; set; }
    }
}