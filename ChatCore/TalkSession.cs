using ChatCore.Data;
using ChatCore.Models;
using ChatCore.States;
using DomainCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public class TalkSession
    {
        [Inject]
        public IUserRepositary UserRepostitary { get; set; }

        public Message LastMessage { get; set; }

        public TalkSession(String from,String to)
        {
            State = new NewState();
            From = from;
            To = to;
        }

        public String From { get; private set; }
        public String To { get; private set; }

        public BaseState State { get; set; }

        public void Request(Message msg)
        {
            State.Handle(this, msg, string.Empty);
        }

        public ReplyMessage ReplyMessage
        {
            get
            {
                return State.Message;
            }
        }
    }
}
