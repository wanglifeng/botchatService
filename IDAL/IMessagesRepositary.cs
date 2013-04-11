using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace ChatCore
{
    public interface IMessagesRepositary
    {
        List<StateMessage> GetMessages(object state, Language language);
    }
}
