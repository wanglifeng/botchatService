using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Patterns
{
    static class SearchPatternExtensions
    {
        public static bool IsSearchStart(this string str)
        {
            var s = str.ToLower();
            var searchStrings = new List<String> { "search", "搜", "搜职位", "找工作", "工作", "职位" };
            return searchStrings.SingleOrDefault(t => t == str) != null;
        }

        public static bool IsGoToNextPage(this string str)
        {
            var s = str.ToLower();
            var searchStrings = new List<String> { "1", "下", "下一页" };
            return searchStrings.SingleOrDefault(t => t == str) != null;
        }

        public static bool IsGoToPrePage(this string str)
        {
            var s = str.ToLower();
            var searchStrings = new List<String> { "2", "上", "上一页" };
            return searchStrings.SingleOrDefault(t => t == str) != null;
        }

        public static bool IsGoToJobResultDirectly(this string str)
        {
            var s = str.ToLower();
            var searchStrings = new List<String> { "go", "完成" };
            return searchStrings.SingleOrDefault(t => t == str) != null;
        }
    }
}
