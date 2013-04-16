using DomainCore;
using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;
using Ninject;
using ChatCore.States.SearchStates;
using Me.WLF.IDAL;

namespace ChatCore.States.UserProfileStates
{
    public class UserProfileState : BaseState
    {
        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (msg is RequestTextMessage)
            {
                var m = msg as RequestTextMessage;

                if (!String.IsNullOrEmpty(m.Content))
                {
                    if (m.Content == "1")
                        session.State = Kernel.Get<UserProfileWaitNameState>();
                    else if (m.Content == "2")
                        session.State = Kernel.Get<UserProfileWaitNameState>();
                    else if (PatternManager.IsSearchStartPattern(m.Content))
                        session.State = Kernel.Get<SearchStartStates>();

                }
            }
            PreMsg = Kernel.Get<IConstMessageRepositary>().GetMessage("ShoudBe1Or2", _TalkSession.Language); ; ;
        }
    }
}
