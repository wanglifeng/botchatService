using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    public abstract class BaseSearchState : BaseState
    {
        public override void Handle(TalkSession session, Message msg)
        {
            HandleMsg(session,msg);
        }

        public abstract Message HandleMsg(TalkSession session, Message msg);

        public override abstract String Content { get; }
    }
}
