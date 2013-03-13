using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Patterns
{
    static class UserProfileExtensions
    {
        public static bool IsUserProfileStart(this string str)
        {
            var s = str.ToLower();
            var searchStrings = new List<String> { "profile", "个人资料", "资料" };
            return searchStrings.SingleOrDefault(t => t == str) != null;
        }
    }
}
