using ChatCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    public abstract class BaseSearchState : BaseState
    {
        public JobSearchModel Search { get; set; }

        public override void Handle(TalkSession session, Message msg)
        {
            HandleMsg(session,msg);
        }

        public abstract void HandleMsg(TalkSession session, Message msg);

        public override abstract String Content { get; }
    }
}
