using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace Slack.Client.Extensions
{
    public static class JsonExtensions
    {
        public static string ToQuery(this string source)
        {
            string objectQuery = "?";
            objectQuery += source.Replace(":", "=").Replace("{", "").
                        Replace("}", "").Replace(",", "&").
                            Replace("\"", "");

            return objectQuery;
        }

        public static IDictionary<string, object> ToDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            string objectJson = JsonConvert.SerializeObject(source);
            Dictionary<string, object> objectDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(objectJson);

            return objectDictionary;
        }
    }
}