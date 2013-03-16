using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;

namespace ChatCore.States
{
    public class NewUserState : NewState
    {
        public override ReplyMessage Message
        {
            get
            {
                return new ReplyTextMessage()
                {
                    From = _TalkSession.To,
                    To = _TalkSession.From,
                    SentTime = DateTime.Now,
                    Content = "欢迎您的加入"
                };
            }
        }
    }
}
