using System;

namespace MinhHelper
{
    public static class StringHelper
    {
        public static string? RemoveRedundantWhitespaces(this string input)
        {
            if (!String.IsNullOrEmpty(input) && !String.IsNullOrWhiteSpace(input))
                return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ");

            return null;
        }

    }
}
