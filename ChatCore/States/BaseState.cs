using ChatCore.Models;
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
            Handle(session, msg);
            session.State._TalkSession = session;
        }

        public abstract void Handle(TalkSession session, Message msg);

        public abstract String Content { get; }

        public abstract ReplyMessage Message { get; }
    }
}
