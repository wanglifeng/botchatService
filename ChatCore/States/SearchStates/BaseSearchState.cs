using ChatCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace ChatCore.States.SearchStates
{
    public abstract class BaseSearchState : BaseState
    {
        public JobSearchModel Search { get; set; }

        public override void Handle(TalkSession session, RequestMessage msg)
        {
            HandleMsg(session,msg);
        }

        public abstract void HandleMsg(TalkSession session, RequestMessage msg);
    }
}
