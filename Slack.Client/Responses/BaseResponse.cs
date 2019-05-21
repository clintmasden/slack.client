using System;

namespace Slack.Client.Responses
{
    public class BaseResponse
    {
        public bool Ok;

        public string Error;

        public void AssertOk()
        {
            if (!(Ok))
                throw new InvalidOperationException(string.Format("An error occurred: {0}", this.Error));
        }
    }
}