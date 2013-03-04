using ChatCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChatCore.States.UserProfileStates
{
    public class UserProfileWaitNameState : BaseState
    {
        private List<String> Msgs = null;

        public UserProfileWaitNameState()
        {
            Msgs = new List<string>
            {
                "请输入名字吧",
                "你叫什么名字呀?",
                "你的名字?",
                "What's your name?"
            };
        }

        public override void Handle(TalkSession session, Message msg)
        {
            if (ChineseNameHelper.IsValid(msg.Content))
            {
                session.State = new UserProfileState() { PreMsg = "输入成功" };
            }
        }

        public override string Content
        {
            get
            {
                Random r = new Random();
                Thread.Sleep(1000);
                return Msgs[r.Next(0, Msgs.Count)];
            }
        }
    }
}
