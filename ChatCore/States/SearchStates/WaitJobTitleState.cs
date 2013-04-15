using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using ChatCore.States.UserProfileStates;

namespace ChatCore.States.SearchStates
{
    public class WaitJobTitleState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, RequestMessage message)
        {
            var msg = message as RequestTextMessage;

            if (PatternManager.IsUserProfileStart(msg.Content))
                session.State = Kernel.Get<UserProfileState>();
            else
            {
                WaitLocationState s = Kernel.Get<WaitLocationState>();
                s.Search = new JobSearchModel() { JobTitle = msg.Content };
                session.State = s;
            }
        }
    }
}
