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

namespace ChatCore.States
{
    public class NewState : BaseState
    {
        private String _Content = string.Empty;

        public override void Handle(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                if (msg.Content.IsSearchStart())
                    session.State = new SearchStartStates();
                else if (msg.Content.IsUserProfileStart())
                    session.State = new UserProfileState();
                else if (msg.Content.IsNewUser())
                    session.State = new NewUserState();
                else
                {
                    //IQuestionRepositary repo = new QuestionRepostaryByDB();
                    //Question q = repo.GetByQuestion(msg.Content);
                    //if (q != null)
                    //    _Content = q.Answer;
                }
            }
        }

        public override string Content
        {
            get
            {
                if (String.IsNullOrEmpty(_Content))
                    return "1.Search 找工作\n 2 Profile 填写个人资料 \n3 提问";
                else
                    return _Content;
            }
        }

        public override Models.ReplyMessage Message
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
                return new ReplyTextMessage()
                {
                    Content = str[r.Next(0, str.Count - 1)],
                    CreateDT = DateTime.Now,
                    From = _TalkSession.To,
                    To = _TalkSession.From
                };
            }
        }
    }
}
