using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    class WaitLocationState : BaseSearchState
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
    }
}
