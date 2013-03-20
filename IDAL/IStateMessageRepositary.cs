using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.IDAL
{
    public interface IStateMessageRepositary
    {
        List<String> Messages(string stateName, string language);
    }
}
