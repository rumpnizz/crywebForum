using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace cryWeb.Helpers
{
    public static class UrlHelper
    {
        public static string RemoveAccent(this string s)
        {
            return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(s));
        }

        public static string Clean(this string s)
        {
            var sb = new StringBuilder(
                Regex.Replace(
                    HttpUtility.HtmlDecode(s.Replace("&", "och")).RemoveAccent(), @"(?!W+$)W+(?<!^W+)", "").Trim());
            sb.Replace(":", " ").Replace("-", "").Replace(",", " ").Replace("  ", " ").Replace(" ", "-");

            return sb.ToString().ToLower();
        }
    }
}