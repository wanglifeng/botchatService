using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.IDAL
{
    public interface IConstMessageRepositary
    {
        String GetMessage(string format, Language language, params  string[] orgs);
        void Save(ConstMessage message);
        List<ConstMessage> List();
        void Del(int id);
        ConstMessage GetById(int id);
    }
}
