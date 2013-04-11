using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Me.WLF.Model;

namespace ChatCore
{
    public class MessageHandler
    {
        public void HandleRequest(MessageRequestContext requestContext, MessageReplyContext responseContext)
        {
            requestContext.Session.Request(requestContext.MessageRequest);
            var msg = requestContext.Session.ReplyMessage;
            if (msg is ReplyTextMessage)
            {
                if (!String.IsNullOrEmpty(requestContext.Session.State.PreMsg))
                    (msg as ReplyTextMessage).Content = string.Format("{0}\n{1}", requestContext.Session.State.PreMsg, (msg as ReplyTextMessage).Content);
            }
            responseContext.ReplyMessage = msg;
        }
    }
}
