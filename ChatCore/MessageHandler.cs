using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Me.WLF.Model;
using Ninject;
using Me.WLF.IDAL;

namespace ChatCore
{
    public class MessageHandler
    {
        public void HandleRequest(MessageRequestContext requestContext, MessageReplyContext responseContext)
        {
            var repo = KernelManager.Kernel.Get<IMessageRepositary>();
            repo.Save(requestContext.MessageRequest);

            requestContext.Session.Request(requestContext.MessageRequest);
            var msg = requestContext.Session.ReplyMessage;
            if (msg is ReplyTextMessage)
            {
                if (!String.IsNullOrEmpty(requestContext.Session.State.PreMsg))
                    (msg as ReplyTextMessage).Content = string.Format("{0}{1}{2}", requestContext.Session.State.PreMsg, System.Environment.NewLine, (msg as ReplyTextMessage).Content);

                requestContext.Session.State.PreMsg = string.Empty;
            }
            responseContext.ReplyMessage = msg;

            repo.Save(msg);
        }
    }
}
