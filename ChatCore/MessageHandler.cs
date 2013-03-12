using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public class MessageHandler
    {
        public void HandleRequest(MessageRequestContext context,MessageReplyContext replyContext)
        {
            context.Session.Request(context.MessageRequest);
            replyContext.ReplyMessage = context.Session.ReplyMessage;
        }
    }
}
