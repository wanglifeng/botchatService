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
                return new ReplyTextMessage()
                {
                    Content = "开始输入关键字找工作吧?没啥写的就敲个空格点发送吧？",
                    CreateDT = DateTime.Now,
                    From = _TalkSession.Message.To,
                    To = _TalkSession.Message.From
                };
            }
        }
    }
}
