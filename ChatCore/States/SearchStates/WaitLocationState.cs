using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Models;

namespace ChatCore.States.SearchStates
{
    public class WaitLocationState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                Search.Location = msg.Content;

                session.State = new JobResultState()
                {
                    Search = Search
                };
            }
        }

        public override string Content
        {
            get { return "请输入地址"; }
        }

        public override Models.ReplyMessage Message
        {
            get
            {
                return new ReplyTextMessage()
                {
                    Content = "请输入地址",
                    CreateDT = DateTime.Now,
                    From = _TalkSession.Message.To,
                    To = _TalkSession.Message.From
                };
            }
        }
    }
}
