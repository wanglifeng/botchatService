using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Me.WLF.IDAL;

namespace ChatCore.Utils
{
    class ChineseNameHelper
    {
        public IChineseLastNameRepositary ChineseLastNameRepositary { get; set; }

        public bool IsValid(String name)
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
