using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace cryWeb.Extensions
{
    public static class StringExtensions
    {
        public static string ToMaxLength(this string str, int maxLength)
        {
            return str.Length > maxLength ? str.Substring(0, maxLength) : str;
        }
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            const string regex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            return new Regex(regex).IsMatch(email);
        }
    }
}