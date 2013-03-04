using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class ChineseLastNameRepositaryByDB : IChineseLastNameRepositary
    {
        public List<string> ValidChineseLastNames
        {
            get
            {
                string names = "张 王 李 赵";
                return names.Split(new char[] { ' ' }).ToList();
            }
        }
    }
}
