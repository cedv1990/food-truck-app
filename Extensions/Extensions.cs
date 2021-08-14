using System;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class Extensions
    {
        public static readonly string NONE = "NotSpecified";
        
        public static bool IsInValid(this Enum enumType)
        {
            return !Enum.IsDefined(enumType.GetType(), enumType);
        }

        public static string CleanSpaces(this string value)
        {
            return value == null ? NONE : Regex.Replace(value, @"\s+", string.Empty);
        }
    }
}