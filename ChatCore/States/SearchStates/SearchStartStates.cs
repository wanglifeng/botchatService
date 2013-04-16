using ChatCore.Models;
using ChatCore.States.UserProfileStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;
using Ninject;

namespace ChatCore.States.SearchStates
{
    public class SearchStartStates : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, RequestMessage message)
        {
            var msg = message as RequestTextMessage;

            if (msg.Content.ToLower() == "Profile")
                session.State = Kernel.Get<UserProfileState>();
            else
            {
                WaitLocationState s = Kernel.Get<WaitLocationState>();
                s.Search = new JobSearchModel() { Keyword = msg.Content };
                session.State = s;
            }
        }
    }
}
