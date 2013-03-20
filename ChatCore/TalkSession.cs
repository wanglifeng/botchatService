using ChatCore.Models;
using ChatCore.States;
using DomainCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.IDAL;
using Me.WLF.Model;

namespace ChatCore
{
    public class TalkSession
    {
        public RequestMessage LastMessage { get; set; }

        [Inject]
        public IUserRepositary UserRepositary { get; set; }

        public TalkSession() { State = KernelManager.Kernel.Get<NewState>(); }

        public TalkSession(String from, String to)
        {
            State = KernelManager.Kernel.Get<NewState>(); // new NewState();
            From = from;
            To = to;
        }

        public String From { get; set; }
        public String To { get; set; }

        public BaseState State { get; set; }

        public void Request(RequestMessage msg)
        {
            State.Handle(this, msg, string.Empty);
        }
        public Language Language
        {
            get
            {
                if (User == null)
                    return Me.WLF.Model.Language.None;
                else
                    return User.Language;
            }
        }

        public User User
        {
            get
            {
                var user = UserRepositary.GetByUserName(From);
                if (user == null)
                {
                    user = new User() { UserName = From };
                    UserRepositary.Save(user);
                    user = UserRepositary.GetByUserName(From);
                }
                return user;
            }
        }

        public ReplyMessage ReplyMessage { get { return State.Message; } }
    }
}
