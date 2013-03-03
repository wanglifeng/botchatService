using ChatCore.States.SearchStates;
using ChatCore.States.UserProfileStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States
{
    public class NewState : BaseState
    {
        public override void Handle(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                if (msg.Content.ToLower() == "search")
                    session.State = new SearchStartStates();
                else if (msg.Content.ToLower() == "profile")
                    session.State = new UserProfileState();
                else if (msg.Content.ToLower() == "hello2biz")
                    session.State = new NewUserState();
            }
        }

        public override string Content
        {
            get { return "1.Search 找工作\n 2 Profile 填写个人资料 \n3 提问"; }
        }
    }
}
