using ChatCore.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public class TalkSession
    {
        public TalkSession()
        {
            State = new NewState();
        }

        public BaseState State { get; set; }

        public void Request(Message msg)
        {
            State.Handle(this, msg);
        }
    }
}
