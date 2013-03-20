using ChatCore.Models;
using ChatCore.Patterns.Validators;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Patterns
{
    public class PatternManager : IPatternManager
    {
        private List<ErrorCodes> _Messages = new List<ErrorCodes>();

        [Inject]
        private IChineseLastNameValidator ChineseLastNameValidator { get; set; }

        public bool IsChineseLastName(string value)
        {
            return ChineseLastNameValidator.Valid(value, _Messages);
        }

        public List<ErrorCodes> ValidMessages { get { return _Messages; } }


        public bool IsSearchStartPattern(string value)
        {
            var s = value.ToLower();
            var searchStrings = new List<String> { "search", "搜", "搜职位", "找工作", "工作", "职位" };
            return searchStrings.SingleOrDefault(t => t == s) != null;
        }


        public bool IsUserProfileStart(string value)
        {
            var s = value.ToLower();
            var searchStrings = new List<String> { "profile", "个人资料", "资料" };
            return searchStrings.SingleOrDefault(t => t == s) != null;
        }

        public bool IsNewRegisterUser(string value)
        {
            return string.Compare(value, "Hello2UserBiz", true) == 0;
        }


        public bool IsFeedBackPattern(string value)
        {
            return value.StartsWith("F", StringComparison.CurrentCultureIgnoreCase);
        }


        public bool IsGoToNextPage(string p)
        {
            return p == "1";
        }

        public bool IsGoToPrePage(string p)
        {
            return p == "2";
        }


        public bool IsValidLanguage(string p)
        {
            String[] validLanguages = { "Chinese", "English", "中文", "英文" };
            return Array.Exists<String>(validLanguages, t => t.ToLower() == p.ToLower());
        }
    }
}
