using ChatCore.Models;
using ChatCore.States.UserProfileStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    public class SearchStartStates : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, Message msg)
        {
            if (msg.Content.ToLower() == "Profile")
                session.State = new UserProfileState();
            else
                session.State = new WaitLocationState()
                {
                    Search = new JobSearchModel()
                        {
                            Keyword = msg.Content
                        }
                };
        }

        public override string Content
        {
            get
            {
                return "开始输入关键字找工作吧？";
            }
        }

        public override Models.ReplyMessage Message
        {
            get
            {
                List<String> str = new List<string>
                {
                    "开始输入关键字找工作吧",
                    "你想找哪个公司的工作？",
                    "你想在哪个公司工作？",
                    "你的期望职位是什么"
                };
                Random r = new Random(DateTime.Now.Millisecond);
                return new ReplyTextMessage()
                {
                    Content = str[r.Next(0, str.Count - 1)],
                    CreateDT = DateTime.Now,
                    From = _TalkSession.LastMessage.To,
                    To = _TalkSession.LastMessage.From
                };
            }
        }
    }
}
