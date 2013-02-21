using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.UserProfileStates
{
    public class UserProfileState : BaseState
    {
        public override void Handle(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                if (msg.Content == "1")
                {
                    session.State = new UserProfileWaitNameState();
                }
            }
        }



        public override string Content
        {
            get
            {
                return "啊欧，开始填写您的详细资料吧？";
            }
        }
    }
}
