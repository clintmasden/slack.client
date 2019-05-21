using System.Collections.Generic;

namespace Slack.Client.Extensions
{
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            var newObject = new T();
            var objectType = newObject.GetType();

            foreach (var item in source)
            {
                objectType
                         .GetProperty(item.Key)
                         .SetValue(newObject, item.Value, null);
            }

            return newObject;
        }
    }
}