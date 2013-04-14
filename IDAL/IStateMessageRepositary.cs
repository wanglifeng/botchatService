using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace Me.WLF.IDAL
{
    public interface IStateMessageRepositary
    {
        List<StateMessage> Messages(object state, Language language);
        List<StateMessage> Messages(int stateId);
        void Save(StateMessage msg);

        void Del(int id);
    }
}
