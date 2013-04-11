using DomainCore;
using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;
using Ninject;

namespace ChatCore.States.UserProfileStates
{
    public class UserProfileState : BaseState
    {
        private String _Content = string.Empty;

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

                }
            }
            PreMsg = "you must entern 1 or 2 ~";
        }

        public override ReplyMessage Message
        {
            get
            {
                var content = string.Empty;
                if (!String.IsNullOrEmpty(PreMsg))
                    content = string.Format("{0}\n", PreMsg);
                return new ReplyTextMessage()
                {
                    Content = content + "开始填写您的详细资料吧？输入1就可以输入姓名啦",
                    SentTime = DateTime.Now,
                    From = _TalkSession.To,
                    To = _TalkSession.From
                };
            }
        }
    }
}
