
# slack.client
A .NET Standard/C# implementation of Slack.com API.

| Name | Resources |
| ------ | ------ |
| APIs | https://api.slack.com/methods |

#### Getting Started:
```
using System;
using Slack.Client;
using Slack.Client.Data;

namespace Slack.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new SlackClient("APIKEY");

            var userList client.GetUsers().Result;

            userList.ForEach(user => Console.WriteLine($"{user.Id}. {user.Name}"));
            Console.Read();
        }
    }
}
```
