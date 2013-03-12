using BotChatService.App_Start;
using BotChatService.Models;
using ChatCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Ninject;

namespace BotChatService.Controllers
{
    public class MessagesController : Controller
    {
        [HttpGet]
        public ActionResult Index(String signature, string timestamp, string nonce, string echostr)
        {
            return new ContentResult() { Content = echostr };
        }

        [HttpPost]
        public ActionResult Index()
        {
            string xmlContent = string.Empty;
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                xmlContent = sr.ReadToEnd();
            }
            WeChatRequestMessage msg = WeChatRequestMessage.CreateFromXml(xmlContent);


            MessageHandler handler = new MessageHandler();
            var request = NinjectWebCommon.kernel.Get<MessageRequestContext>();

            var response = new MessageReplyContext();

            request.MessageRequest = new ChatCore.Message()
            {
                Content = (msg as WeChatRequestTextMessage).Content,
                From = msg.FromUserName,
                SentTime = msg.CreateTime,
                To = msg.ToUserName
            };
            handler.HandleRequest(request, response);


            WeChatResponseMessage rsp = WeChatResponseMessage.GetMessage(response.ReplyMessage);


            string xmlResponseContent = rsp.ConvertToWeiChatResponse();

            return new ContentResult() { Content = xmlResponseContent };

        }
    }
}