using Newtonsoft.Json;
using RestEase;
using Slack.Client.Dtos;
using Slack.Client.Extensions;
using Slack.Client.Interfaces;
using Slack.Client.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Slack.Client.Data
{
    /// <summary>
    /// Creates client for accessing slack's api's.
    /// </summary>
    public class SlackClient
    {
        private ISlackClient _slackClient { get; set; }

        /// <summary>
        /// Creates client for accessing slack's api's.
        /// </summary>
        /// <param name="apiToken">the api key for accessing information.</param>
        public SlackClient(string apiToken)
        {
            // For VS15 -  System.AggregateException' in mscorlib.dll
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Setting up Interface
            _slackClient = RestClient.For<ISlackClient>("https://slack.com/api/");
            _slackClient.ApiToken = apiToken;
        }

        /// <summary>
        /// Lists all users in a Slack team.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsers()
        {
            var result = await _slackClient.GetUsersAsync();
            result.AssertOk();

            var userList = result.Users.Where(c => c.Deleted != true).ToList();
            userList = userList.OrderBy(c => c.Name).ToList();

            return userList;
        }

        /// <summary>
        /// Lists all users in a Slack team limited by criteria.
        /// </summary>
        /// <param name="criteria">Realname, name, or email</param>
        /// <returns></returns>
        public async Task<List<User>> GetUsersByCriteria(string criteria)
        {
            var result = await _slackClient.GetUsersAsync();
            result.AssertOk();

            criteria = criteria.ToLower();
            var userList = new List<User>();

            result.Users.Where(c => c.Deleted != true).ToList().ForEach(user =>
            {
                if (!string.IsNullOrWhiteSpace(user.RealName) && user.RealName.ToLower().Contains(criteria))
                {
                    userList.Add(user);
                }
                else if (!string.IsNullOrWhiteSpace(user.Name) && user.Name.ToLower().Contains(criteria))
                {
                    userList.Add(user);
                }
                else if (user.Profile != null && !string.IsNullOrWhiteSpace(user.Profile.Email) && user.Profile.Email.ToLower().Contains(criteria))
                {
                    userList.Add(user);
                }
            });

            userList = userList.OrderBy(c => c.Name).ToList();

            return userList;
        }

        /// <summary>
        /// Gets information about a user.
        /// </summary>
        /// <param name="userId">User to get info on. [W1234567890]</param>
        /// <returns></returns>
        public async Task<User> GetUserById(string userId)
        {
            var result = await _slackClient.GetUserByIdAsync(userId);
            result.AssertOk();

            var user = result.User;

            return user;
        }

        /// <summary>
        /// Find a user with an email address.
        /// </summary>
        /// <param name="email">An email address belonging to a user in the workspace.</param>
        /// <returns></returns>
        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _slackClient.GetUsersAsync();
            result.AssertOk();

            var user = result.Users.Where(c =>
            c.Profile != null &&
            c.Profile.Email != null &&
            c.Profile.Email.ToLower().Contains(email.ToLower())).SingleOrDefault();

            return user;
        }

        /// <summary>
        /// Sends a message or attachments to a channel, private group, or user.
        /// </summary>
        /// <param name="postMessageDto">{ChannelId: Required [Channel, private group, or IM channel to send message to], Text: Required [Optional if spending attachments], AsUser: Required [True to post the message as the authed user, instead of as a bot.] }</param>
        /// <returns></returns>
        public async Task<Message> PostMessage(PostMessageDto postMessageDto)
        {
            // Because slack's platform isn't current.
            var attachments = postMessageDto.Attachements;
            string attachmentsJson = JsonConvert.SerializeObject(attachments);
            postMessageDto.Attachements = null;

            var values = postMessageDto.ToDictionary();

            var result = await _slackClient.PostMessageAsync(values, attachmentsJson);
            result.AssertOk();

            var message = result.Message;

            return message;
        }

        /// <summary>
        /// This method deletes a message from a channel.
        /// </summary>
        /// <param name="deleteMessageDto"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMessage(DeleteMessageDto deleteMessageDto)
        {
            var values = deleteMessageDto.ToDictionary();

            var result = await _slackClient.DeleteMessageAsync(values);
            result.AssertOk();

            return true;
        }

        /// <summary>
        /// This Conversations API method returns a list of all channel-like conversations in a workspace.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Channel>> GetChannels(GetChannelDto getChannelDto)
        {
            var values = getChannelDto.ToDictionary();

            var result = await _slackClient.GetChannelsAsync(values);
            result.AssertOk();

            var channelList = result.Channels;
            channelList = channelList.OrderBy(c => c.Name).ToList();

            return channelList;
        }
    }
}