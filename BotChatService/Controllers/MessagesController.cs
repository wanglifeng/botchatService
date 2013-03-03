using BotChatService.Models;
using ChatCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

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

            TalkSession talkSession = new TalkSession(msg.FromUserName);
            talkSession.Request(new Message()
            {
                Content = (msg as WeChatRequestTextMessage).Content,
                From = msg.FromUserName,
                SentTime = msg.CreateTime,
                To = msg.ToUserName
            });


            WeChatResponseMessage rsp = new WeChatResponseTextMessage()
            {
                FromUser = msg.ToUserName,
                ToUser = msg.FromUserName,
                Content = talkSession.Message.Content
            };

            string xmlResponseContent = rsp.ConvertToWeiChatResponse();

            return new ContentResult() { Content = xmlResponseContent };

        }
    }
}