using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Patterns
{
    static class NewUserExtensions
    {
        public static Boolean IsNewUser(this string str)
        {
            return str.ToLower() == "Hello2BizUser".ToLower();
        }
    }
}
