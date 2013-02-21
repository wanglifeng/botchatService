using ChatCore.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public class TalkSession
    {
        public TalkSession(String from)
        {
            State = new NewState();
            From = from;
        }

        public String From { get; private set; }

        public BaseState State { get; set; }

        public void Request(Message msg)
        {
            State.Handle(this, msg);
        }

        public Message Message
        {
            get
            {
                return new Message()
                {
                    From = "weixin",
                    To = From,
                    Content = String.Format("{0}{1}", State.PreMsg, State.Content),
                    SentTime = DateTime.Now
                };
            }
        }
    }
}
