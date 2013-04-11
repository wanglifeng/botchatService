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
        public IUserRepositary UserRepositary { get; set; }

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
                    state.PreMsg = "Saved";
                    session.State = state;
                }
                else
                {
                    PreMsg = "failured";
                }
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                Msgs = StateMessageRepositary.Messages(this, _TalkSession.Language).Select(t => t.Content).ToList();
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
