using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.IDAL
{
    public interface IMessageRepositary
    {
        void Save(Message msg);
        List<Message> List(string from);
    }
}
