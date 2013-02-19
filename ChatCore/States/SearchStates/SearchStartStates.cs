using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    public class SearchStartStates : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content) && msg.Content == "User")
                session.State = new UserProfileState();
        }
    }
}
