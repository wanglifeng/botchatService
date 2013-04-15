using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.IDAL;
using Me.WLF.Model;

namespace ChatCoreConsole
{
    class ChineseLastNameRepositaryByStaticClass : IChineseLastNameRepositary
    {
        private List<ChineseLastName> names = new List<ChineseLastName> {
            new ChineseLastName(){ LastName="w"}
        };

        public List<string> ValidChineseLastNames
        {
            get { return names.Select(t => t.LastName).ToList(); }
        }

        public List<ChineseLastName> List()
        {
            return names;
        }

        public void Save(Me.WLF.Model.ChineseLastName name)
        {
            names.Add(name);
        }

        public void Del(int id)
        {
            names.RemoveAll(t => t.Id == id);
        }
    }
}
