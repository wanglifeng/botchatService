using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Models;
using Me.WLF.Model;
using Ninject;

namespace ChatCore.States.SearchStates
{
    public class WaitLocationState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, RequestMessage message)
        {
            var msg = message as RequestTextMessage;
            if (!String.IsNullOrEmpty(msg.Content))
            {
                Search.Location = msg.Content;
                JobResultState state = Kernel.Get<JobResultState>();
                state.Search = Search;
                session.State = state;
            }
        }
    }
}
