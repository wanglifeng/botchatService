using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ChatCore
{
    public class MessageHandler
    {
        public void HandleRequest(MessageRequestContext requestContext, MessageReplyContext responseContext)
        {
            requestContext.Session.Request(requestContext.MessageRequest);
            responseContext.ReplyMessage = requestContext.Session.ReplyMessage;
        }
    }
}
