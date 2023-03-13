using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
