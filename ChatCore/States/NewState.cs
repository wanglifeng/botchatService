using ChatCore.States.SearchStates;
using ChatCore.States.UserProfileStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore;
using DomainCore.Models;
using ChatCore.Models;
using ChatCore.Patterns;

using Me.WLF.Model;
using Me.WLF.IDAL;
using Ninject;
namespace ChatCore.States
{
    public class NewState : BaseState
    {
        [Inject]
        public IFeedBackRepositary FeedBackRepositary { get; set; }

        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (msg is RequestTextMessage)
            {
                var m = msg as RequestTextMessage;
                if (PatternManager.IsSearchStartPattern(m.Content))
                    session.State = Kernel.Get<SearchStartStates>();
                else if (PatternManager.IsUserProfileStart(m.Content))
                    session.State = Kernel.Get<UserProfileState>();
                else if (PatternManager.IsNewRegisterUser(m.Content))
                    session.State = Kernel.Get<NewUserState>();
                else if (PatternManager.IsLanguage(m.Content))
                    session.State = Kernel.Get<WaitLanguageState>();
                else if (PatternManager.IsFeedBackPattern(m.Content))
                {
                    FeedBackRepositary.Save(new Me.WLF.Model.FeedBack()
                    {
                        UserName = msg.From,
                        ClientId = "wechat",
                        Content = m.Content
                    });
                    PreMsg = "谢谢您的反馈";

                    session.State = Kernel.Get<NewState>();
                }
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                List<String> str = new List<string>
                {
                    "输入'工作'开始找工作吧? 太麻烦？那就输入'搜'吧？",
                    "输入'找工作'看看有没有感兴趣的工作？",
                    "输入'个人资料'设置自己的资料，我们将推荐适合您的工作",
                    "输入'资料'看看有什么新发现？"
                };
                Random r = new Random(DateTime.Now.Millisecond);
                string c = string.Empty;
                if (!String.IsNullOrEmpty(PreMsg))
                    c = PreMsg + "\n";
                return new ReplyTextMessage()
                {
                    Content = c + str[r.Next(0, str.Count - 1)],
                    SentTime = DateTime.Now,
                    From = _TalkSession.To,
                    To = _TalkSession.From
                };
            }
        }
    }
}
