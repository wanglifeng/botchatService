using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;

namespace Me.WLF.IDAL
{
    public interface IChineseLastNameRepositary
    {
        List<String> ValidChineseLastNames { get; }

        List<ChineseLastName> List();

        void Save(ChineseLastName name);

        void Del(int id);
    }
}
