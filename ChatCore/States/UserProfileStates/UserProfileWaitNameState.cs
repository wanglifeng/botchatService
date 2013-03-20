using ChatCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DomainCore;
using DomainCore.Models;
using ChatCore.Models;
using Me.WLF.Model;
using Me.WLF.IDAL;
using Ninject;

namespace ChatCore.States.UserProfileStates
{
    public class UserProfileWaitNameState : BaseState
    {
        private List<String> Msgs = null;

        [Inject]
        private IUserRepositary UserRepositary { get; set; }

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

        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (msg is RequestTextMessage)
            {
                var m = msg as RequestTextMessage;
                if (PatternManager.IsChineseLastName(m.Content))
                {
                    var user = UserRepositary.GetByUserName(session.From);
                    user.Name = m.Content;
                    UserRepositary.Save(user);
                    var state = Kernel.Get<UserProfileState>();
                    state.PreMsg = "输入成功";
                    session.State = state;
                }
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                Random r = new Random();

                return new ReplyTextMessage()
                {
                    Content = Msgs[r.Next(0, Msgs.Count)],
                    SentTime = DateTime.Now,
                    From = _TalkSession.To,
                    To = _TalkSession.From
                };
            }
        }
    }
}
