using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Utils
{
    class ChineseNameHelper
    {
        public static bool IsValid(String name)
        {
            return name.StartsWith("王");
        }
    }
}
