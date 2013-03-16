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
namespace ChatCore.States
{
    public class NewState : BaseState
    {
        private IFeedBackRepositary _FeedBackRepositary;

        public IFeedBackRepositary FeedBackRepositary
        {
            get
            {
                if (_FeedBackRepositary == null)
                {
                    var feedBackRepositaryClassName = System.Configuration.ConfigurationManager.AppSettings["IFeedBack"];
                    Console.WriteLine(feedBackRepositaryClassName);
                    _FeedBackRepositary = Activator.CreateInstance(Type.GetType(feedBackRepositaryClassName)) as IFeedBackRepositary;
                }
                return _FeedBackRepositary;
            }
        }

        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (msg is RequestTextMessage)
            {
                var m = msg as RequestTextMessage;
                if (PatternManager.IsSearchStartPattern(m.Content))
                    session.State = new SearchStartStates();
                else if (PatternManager.IsUserProfileStart(m.Content))
                    session.State = new UserProfileState();
                else if (PatternManager.IsNewRegisterUser(m.Content))
                    session.State = new NewUserState();
                else if (PatternManager.IsFeedBackPattern(m.Content))
                {
                    FeedBackRepositary.Save(new Me.WLF.Model.FeedBack()
                    {
                        UserName = msg.From,
                        ClientId = "wechat",
                        Content = m.Content
                    });
                    PreMsg = "谢谢您的反馈";
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
