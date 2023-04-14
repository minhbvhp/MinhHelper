namespace MinhHelper
{
    public static class StringHelper
    {
        public static string RemoveRedundantWhitespaces(this string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ");
        }

    }
}
