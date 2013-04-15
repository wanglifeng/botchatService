using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Models;
using Me.WLF.Model;
using Ninject;

namespace ChatCore.States.SearchStates
{
    public class WaitLocationState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, RequestMessage message)
        {
            var msg = message as RequestTextMessage;
            if (!String.IsNullOrEmpty(msg.Content))
            {
                Search.Location = msg.Content;
                JobResultState state = Kernel.Get<JobResultState>();
                state.Search = Search;
                session.State = state;
            }
        }

        //public override ReplyMessage Message
        //{
        //    get
        //    {
        //        List<String> str = new List<string>
        //        {
        //            "请输入地址",
        //            "你现在在哪个城市？",
        //            "你想在哪个城市工作？",
        //            "你想找哪个城市的工作？"
        //        };
        //        Random r = new Random(DateTime.Now.Millisecond);
        //        return new ReplyTextMessage()
        //        {
        //            Content = str[r.Next(0, str.Count - 1)],
        //            SentTime = DateTime.Now,
        //            From = _TalkSession.To,
        //            To = _TalkSession.From
        //        };
        //    }
        //}
    }
}
