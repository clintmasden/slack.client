using Slack.Client.Models;

namespace Slack.Client.Responses
{
    public class UserResponse : BaseResponse
    {
        public User User { get; set; }
    }
}