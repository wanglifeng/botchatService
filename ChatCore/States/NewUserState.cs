using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;
using Ninject;

namespace ChatCore.States
{
    public class NewUserState : NewState
    {
        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (PatternManager.IsValidLanguage((msg as RequestTextMessage).Content))
            {
                session.State = Kernel.Get<NewState>();
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                return new ReplyTextMessage()
                {
                    From = _TalkSession.To,
                    To = _TalkSession.From,
                    SentTime = DateTime.Now,
                    Content = "Welcome, please set your language"
                };
            }
        }
    }
}
