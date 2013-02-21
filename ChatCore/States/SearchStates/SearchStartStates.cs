using ChatCore.States.UserProfileStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    public class SearchStartStates : BaseSearchState
    {
        public override Message HandleMsg(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content) && msg.Content == "User")
            {
                session.State = new UserProfileState();
            }
            return new Message()
{
    From = msg.To,
    To = msg.From,
    Content = session.State.Content,
    SentTime = DateTime.Now
};
        }

        public override string Content
        {
            get
            {
                return "开始输入关键字找工作吧？";
            }
        }
    }
}
