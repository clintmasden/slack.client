using Newtonsoft.Json;

namespace Slack.Client.Dtos
{
    //See: https://api.slack.com/docs/attachments
    public class AttachmentDto
    {
        [JsonProperty("callback_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("fallback", NullValueHandling = NullValueHandling.Ignore)]
        public string Fallback { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("pretext", NullValueHandling = NullValueHandling.Ignore)]
        public string PreText { get; set; }

        [JsonProperty("author_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        [JsonProperty("author_link", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorLink { get; set; }

        [JsonProperty("author_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorIcon { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("title_link", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLink { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public Field[] Fields { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("thumb_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbUrl { get; set; }

        [JsonProperty("mrkdwn_in", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MarkdownIn { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public AttachmentAction[] Actions { get; set; }

        [JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
        public string Footer { get; set; }

        [JsonProperty("footer_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string FooterIcon { get; set; }
    }

    public class Field
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("short")]
        public bool Short { get; set; }
    }

    //See: https://api.slack.com/docs/message-attachments#action_fields
    //See: https://api.slack.com/docs/message-buttons
    public class AttachmentAction
    {
        public AttachmentAction()
        {
        }

        public AttachmentAction(string text, string url)
        {
            this.Text = text;
            this.Type = "button";
            this.Style = "primary";
            this.Url = url;
        }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public string Style { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("confirm", NullValueHandling = NullValueHandling.Ignore)]
        public ActionConfirm Confirm { get; set; }
    }

    //see: https://api.slack.com/docs/message-buttons#confirmation_fields
    public class ActionConfirm
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ok_text")]
        public string OkText { get; set; }

        [JsonProperty("dismiss_text")]
        public string DismissText { get; set; }
    }
}