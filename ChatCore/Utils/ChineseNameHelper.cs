using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Utils
{
    class ChineseNameHelper
    {
        private static IChineseLastNameRepositary ChineseLastNameRepositary
        {
            get
            {
                return new ChineseLastNameRepositaryByDB();
            }
        }

        public static bool IsValid(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                if (name.Length >= 2 && name.Length <= 5)
                {
                    return ChineseLastNameRepositary.ValidChineseLastNames.Contains(name[0].ToString());
                }
            }

            return false;
        }
    }
}
