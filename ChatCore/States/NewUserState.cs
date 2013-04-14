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
            if (msg is RequestTextMessage && PatternManager.IsValidLanguage((msg as RequestTextMessage).Content))
            {
                session.State = Kernel.Get<NewState>();
            }
        }
    }
}
