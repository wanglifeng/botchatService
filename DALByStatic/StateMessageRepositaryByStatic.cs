using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.DALByStatic
{
    public class StateMessageRepositaryByStatic : IStateMessageRepositary
    {
        public List<string> Messages(string stateName, string language)
        {
            return new List<String>
            {
                 String.Format("{0}======={1}",stateName,language)
            };
        }
    }
}
