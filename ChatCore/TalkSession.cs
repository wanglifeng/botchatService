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

        public DateTime LastActivityDT { get; set; }

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
            Console.WriteLine("Pre State:{0}", this.State);
            State.Handle(this, msg, string.Empty);
            Console.WriteLine("Next State:{0}", this.State.GetType());
            this.State._TalkSession = this;
            Console.WriteLine(this.State.Message);
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
                    user = new User() { UserName = From, ClientId = ClientId, RegisterTime = DateTime.Now, Language = Me.WLF.Model.Language.Chinese, Status = "subscribe" };
                    UserRepositary.Save(user);
                    user = UserRepositary.GetByUserName(From);
                }
                return user;
            }
        }

        public String ClientId { get; set; }

        public ReplyMessage ReplyMessage { get { return State.Message; } }
    }
}
