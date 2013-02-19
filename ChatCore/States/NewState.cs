using ChatCore.States.SearchStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States
{
    public class NewState : BaseState
    {
        public override void Handle(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content) && msg.Content == "Search")
                session.State = new SearchStartStates();

            if (!String.IsNullOrEmpty(msg.Content) && msg.Content == "User")
                session.State = new UserProfileState();
        }
    }
}
