using System;
using System.Resources;

namespace Common.Extensions
{
    public static class Util
    {
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length < 1;
        }

        public static bool ValidateItem<T>(this T[] array, T item, bool include)
        {
            bool itemExists = Array.Exists(array, element => element.Equals(item));
            return (include && itemExists) || (!include && !itemExists);
        }

        public static string GetMessage(this Type resource, string key, params object[] arguments)
        {
            ResourceManager Messages = new ResourceManager(resource);
            return Messages == null || string.IsNullOrEmpty(key)
                ? key : string.Format(Messages.GetString(key) ?? key, arguments);
        }
    }
}
