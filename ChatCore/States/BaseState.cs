using ChatCore.Models;
using ChatCore.States.SearchStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States
{
    public abstract class BaseState
    {
        public String PreMsg { get; set; }
        protected TalkSession _TalkSession { get; set; }
        public void Handle(Message msg)
        {

        }

        public void Handle(TalkSession session, Message msg, string str)
        {
            _TalkSession = session;
            session.LastMessage = msg;

            if (msg.Content.ToLower() == "search")
                session.State = new SearchStartStates();
            else if (msg.Content.ToLower() == "profile")
                session.State = new UserProfileStates.UserProfileState();
            else
                Handle(session, msg);
            
            session.State._TalkSession = session;
        }

        public abstract void Handle(TalkSession session, Message msg);

        public abstract String Content { get; }

        public abstract ReplyMessage Message { get; }
    }
}
