using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.IDAL
{
    public interface IConstMessageRepositary
    {
        String GetMessage(string format, Language language);
        void Save(ConstMessage message);
    }
}
