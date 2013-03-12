using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using Enyim.Caching.Configuration;
//using Memcached.ClientLibrary;
//using Enyim.Caching;
using System.Net;
using DomainCore;
using ChatCore.Data;

namespace ChatCoreConsole
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IUserRepositary>().To<UserRepositaryByStaticClass>();
            kernel.Bind<ITalkSessionRepositry>().To<TalkSessionRepositryByStaticClass>();
            kernel.Bind<TalkSession>().ToSelf();
            kernel.Bind<MessageRequestContext>().ToSelf();

            string msg = Console.ReadLine();
            MessageHandler handler = new MessageHandler();
            var request = kernel.Get<MessageRequestContext>();

            var response = new MessageReplyContext();

            while (!string.IsNullOrEmpty(msg))
            {
                request = kernel.Get<MessageRequestContext>();
                request.MessageRequest = new ChatCore.Message()
                {
                    From = "wanglifeng",
                    To = "weichat",
                    Content = msg,
                    SentTime = DateTime.Now
                };
                handler.HandleRequest(request, response);

                Console.WriteLine(response.ReplyMessage.ToString());
                msg = Console.ReadLine();

            }

            //string msgConent = Console.ReadLine();
            //while (!String.IsNullOrEmpty(msgConent))
            //{
            //    session.Request(new Message() { From = "wanglifeng", To = "ROBOT", SentTime = DateTime.Now, Content = msgConent });
            //    Console.WriteLine(session.ReplyMessage.ToString());
            //    msgConent = Console.ReadLine();
            //}
        }

        static void client_NodeFailed(IMemcachedNode obj)
        {

        }
    }
}
