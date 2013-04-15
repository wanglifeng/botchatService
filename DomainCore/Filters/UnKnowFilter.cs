using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore.Filters
{
    class UnKnowFilter:IFilter
    {
        public bool Filters(string userId, string content, out string result)
        {
            result = "我正在理解您的内容, Sorry, I don't understand what's your meaning....";
            return true;
        }
    }
}
