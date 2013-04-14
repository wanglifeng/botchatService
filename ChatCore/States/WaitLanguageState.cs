using Me.WLF.IDAL;
using Me.WLF.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States
{
    public class WaitLanguageState : BaseState
    {
        [Inject]
        public IStateMessageRepositary Repositary { get; set; }

        [Inject]
        public IUserRepositary UserRepositary { get; set; }

        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (msg is RequestTextMessage)
            {
                var m = msg as RequestTextMessage;
                if (PatternManager.IsValidLanguage(m.Content))
                {
                    var user = UserRepositary.GetByUserName(session.From);
                    if (m.Content == "中文") m.Content = "Chinese";
                    if (m.Content == "英文") m.Content = "English";
                    user.Language = (Language)Enum.Parse(typeof(Language), m.Content, true);
                    UserRepositary.Save(user);
                    session.State = Kernel.Get<NewState>();
                    session.State.PreMsg = "输入成功";
                }
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                if (_TalkSession.Language == Language.None)
                {
                    return new ReplyTextMessage()
                    {
                        Content = "输入 Chinese 或 中文 设置您的语言为中文，输入 English 或 英文 设置您的语言为英文",
                        From = _TalkSession.To,
                        To = _TalkSession.From,
                        SentTime = DateTime.Now
                    };
                }
                return base.Message;
            }
        }
    }
}
