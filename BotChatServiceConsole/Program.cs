using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using System.Net;
using DomainCore;
using Me.WLF.IDAL;
using Me.WLF.Model;
using Me.WLF.DALByStatic;
using Newtonsoft.Json;
using ChatCore.Patterns;

namespace ChatCoreConsole
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var kernel = KernelManager.Kernel;
            Console.WriteLine("Please input message");
            string msg = Console.ReadLine();

            MessageHandler handler = new MessageHandler();
            var request = kernel.Get<MessageRequestContext>();

            var response = new MessageReplyContext();

            while (!string.IsNullOrEmpty(msg))
            {
                request = kernel.Get<MessageRequestContext>();
                if (msg != "subscribe")
                {
                    request.MessageRequest = new RequestTextMessage()
                    {
                        From = "wanglifeng",
                        To = "wechat",
                        Content = msg,
                        ClientId = "Console",
                        SentTime = DateTime.Now
                    };
                }
                else
                {
                    request.MessageRequest = new RequestEventMessage()
                    {
                        From = "wanglifeng",
                        ClientId = "console",
                        MsgType = RequestMessage.MessageType.@event,
                        Event = "subscribe",
                        SentTime = DateTime.Now,
                        To = "wechat"
                    };
                }
                handler.HandleRequest(request, response);

                Console.WriteLine(JsonConvert.SerializeObject(response.ReplyMessage));

                msg = Console.ReadLine();

            }
        }
    }
}
