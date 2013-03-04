using DomainCore.Models;
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
                using (ChatContext context = new ChatContext())
                {
                    return context.ChineseLastNames.Select(t => t.LastName).ToList();
                }
                //string names = "张 王 李 赵";
                //return names.Split(new char[] { ' ' }).ToList();
            }
        }


        public List<ChineseLastName> List()
        {
            using (ChatContext context = new ChatContext())
            {
                return context.ChineseLastNames.ToList();
            }
        }


        public void Save(ChineseLastName name)
        {
            using (ChatContext context = new ChatContext())
            {
                context.ChineseLastNames.Add(new ChineseLastName() { LastName = name.LastName });
                context.SaveChanges();
            }
        }
    }
}
