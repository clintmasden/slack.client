using RestEase;
using Slack.Client.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.Client.Interfaces
{
    public interface ISlackClient
    {
        [Path("apiToken")]
        string ApiToken { get; set; }

        [Get("users.list?token={apiToken}")]
        Task<UserListResponse> GetUsersAsync();

        [Get("users.info?token={apiToken}")]
        Task<UserResponse> GetUserByIdAsync([Query("user")] string userId);

        [Get("users.lookupByEmail?token={apiToken}")]
        Task<UserResponse> GetUserByEmailAsync([Query("email")] string userEmail);

        [Post("chat.postMessage?token={apiToken}")]
        Task<PostMessageResponse> PostMessageAsync([QueryMap] IDictionary<string, object> dto, [Query] string attachments);

        [Post("chat.delete?token={apiToken}")]
        Task<DeleteMessageResponse> DeleteMessageAsync([QueryMap] IDictionary<string, object> dto);

        [Get("conversations.list?token={apiToken}")]
        Task<ChannelListResponse> GetChannelsAsync([QueryMap] IDictionary<string, object> dto);
    }
}