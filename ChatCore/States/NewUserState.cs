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
                Random r = new Random(DateTime.Now.Millisecond);
                List<StateMessage> msgs = StateMessageRepositary.Messages(this, _TalkSession.Language);
                return new ReplyTextMessage()
                {
                    From = _TalkSession.To,
                    To = _TalkSession.From,
                    SentTime = DateTime.Now,
                    Content = msgs[r.Next(0, msgs.Count)].Content
                };
            }
        }
    }
}
