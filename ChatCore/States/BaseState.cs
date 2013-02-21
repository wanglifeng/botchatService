using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States
{
    public abstract class BaseState
    {
        public String PreMsg { get; set; }

        public abstract void Handle(TalkSession session, Message msg);

        public abstract String Content { get;  }
    }
}
