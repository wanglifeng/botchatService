using ChatCore.Data;
using ChatCore.Models;
using ChatCore.States;
using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public class TalkSession
    {
        public ITalkSessionRepositry TalkSessionRepositry
        {
            get
            {
                return new TalkSessionRepositryByProgress();
            }
        }

        public Message LastMessage { get; set; }

        public TalkSession(String from)
        {
            State = new NewState();
            if (TalkSessionRepositry.Get(from) != null)
                State = TalkSessionRepositry.Get(from).State;
            else
            {
                //IUserRepositary repo = new UserRepositaryByDB();
                //if (repo.GetByUserName(from) == null)
                //{
                //    repo.Save(new DomainCore.Models.User()
                //    {
                //        ClientId = "weichat",
                //        UserName = from
                //    });
                //}
            }

            From = from;
        }

        public String From { get; private set; }

        public BaseState State { get; set; }

        public void Request(Message msg)
        {
            State.Handle(this, msg, string.Empty);
            TalkSessionRepositry.Save(this);
        }

        public Message Message
        {
            get
            {
                return LastMessage;
            }
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
