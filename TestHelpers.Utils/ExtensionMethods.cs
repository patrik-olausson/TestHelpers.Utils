using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace TestHelpers.Utils
{
    public static class ExtensionMethods
    {
        public static string ReplaceAllMatches(
            this string value,
            string valueToReplace,
            string replacementValue = "ReplacedValue")
        {
            return new Regex(valueToReplace).Replace(value, replacementValue);
        }

        public static bool LooksLikeItContainsJson(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (value.StartsWith("{")) return true;
            if (value.StartsWith("[")) return true;

            return false;
        }

        public static string ToJsonString(this object objectToSerialize, bool indented = true)
        {
            return JsonConvert.SerializeObject(
                objectToSerialize,
                indented ? Formatting.Indented : Formatting.None);
        }

        public static T FromJsonString<T>(this string jsonContent)
        {
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }

        public static DateTimeOffset AsDate(this string dateString)
        {
            DateTimeOffset result;
            if (DateTimeOffset.TryParse(dateString, out result))
                return result;
            else
                throw new FormatException($"{dateString} is not a valid date. Supported date formats include yyyy-MM-dd, yyyy-MM-dd HH:mm:ss, yyyy/MM/dd.");
        }
    }
}