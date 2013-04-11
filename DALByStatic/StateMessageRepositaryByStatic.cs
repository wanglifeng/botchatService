using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace Me.WLF.DALByStatic
{
    public class StateMessageRepositaryByStatic : IStateMessageRepositary
    {
        public List<StateMessage> Messages(object state, Language language)
        {
            return new List<StateMessage>
            {
                 new StateMessage(){ 
                     Content= String.Format("{0}======={1}",state.GetType().FullName,language),
                      Language=language
                 }
            };
        }
    }
}
