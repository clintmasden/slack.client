using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slack.Client.Data;
using Slack.Client.Dtos;
using System;
using System.Collections.Generic;

namespace Slack.Client.Tests
{
    [TestClass]
    public class SlackTests
    {
        private static SlackClient _slackClient;

        [ClassInitialize]
        public static void SetupClient(TestContext con)
        {
            _slackClient = new SlackClient("APIKEY");
        }

        [TestMethod]
        public void Conversation_GetPublicChannelList_Pass()
        {
            var result = _slackClient.GetChannels(new GetChannelDto()).Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Conversation_GetPrivateChannelList_Pass()
        {
            var result = _slackClient.GetChannels(new GetChannelDto { ChannelType = "private_channel" }).Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void User_GetUserList_Pass()
        {
            var result = _slackClient.GetUsers().Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void User_GetUserListByCriteria_Pass()
        {
            var result = _slackClient.GetUsersByCriteria("john").Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void User_GetUserById_Pass()
        {
            var result = _slackClient.GetUserById("U03JUEVEM").Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void User_GetUserByEmail_Pass()
        {
            var result = _slackClient.GetUserByEmail("user@domain.com").Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Message_PostMessage_Pass()
        {
            //https://domain.slack.com/account/settings#username
            var postMessageDto = new PostMessageDto()
            {
                ChannelId = "CAPDNP43H",
                Text = "Unit test - post message",
                AsUser = false,
                BotName = "Unit Test Bot"
            };

            try
            {
                var result = _slackClient.PostMessage(postMessageDto).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Message_DeleteMessage_Pass()
        {
            var deleteMessageDto = new DeleteMessageDto()
            {
                ChannelId = "CAPDNP43H",
                Timestamp = "1558395969.000100",
                AsUser = false,
            };

            try
            {
                var result = _slackClient.DeleteMessage(deleteMessageDto).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Message_PostMessage_Attachment_Pass()
        {
            var postMessageDto = new PostMessageDto()
            {
                ChannelId = "U03JUEVEM",
                AsUser = false,
                BotName = "Unit Test Bot",
                Attachements = new List<AttachmentDto>()
                {
                    new AttachmentDto()
                    {
                        Fallback = "New ticket from Andrea Lee - Ticket #1943: Can't reset my password - https://groove.hq/path/to/ticket/1943",
                        PreText = "New ticket from Andrea Lee",
                        Title = "Ticket #1943: Can't reset my password",
                        TitleLink = "https://groove.hq/path/to/ticket/1943",
                        Text = "Help! I tried to reset my password but nothing happened!",
                        Color = "#7CD197"
                    }
                }
            };

            try
            {
                var result = _slackClient.PostMessage(postMessageDto).Result;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}