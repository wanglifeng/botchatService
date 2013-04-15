using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.IDAL;
using Me.WLF.Model;

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
            }
        }


        public List<ChineseLastName> List()
        {
            using (ChatContext context = new ChatContext())
            {
                var names = new List<ChineseLastName>();
                context.ChineseLastNames.ToList().ForEach(t =>
                    {
                        names.Add((ChineseLastName)t);
                    });
                return names;
            }
        }


        public void Save(ChineseLastName name)
        {
            using (ChatContext context = new ChatContext())
            {
                var n = context.ChineseLastNames.SingleOrDefault(t => t.Id == name.Id);
                if (n == null)
                {
                    context.ChineseLastNames.Add((DomainCore.Models.ChineseLastName)name);
                }
                else
                {
                    n.LastName = n.LastName;
                }
                context.SaveChanges();
            }
        }


        public void Del(int id)
        {
            using (ChatContext context = new ChatContext())
            {
                var name = context.ChineseLastNames.SingleOrDefault(t => t.Id == id);
                if (name != null)
                    context.ChineseLastNames.Remove(name);
                context.SaveChanges();
            }
        }
    }
}
