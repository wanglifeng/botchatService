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
            var kernel = new StandardKernel();
            kernel.Bind<IUserRepositary>().To<UserRepositaryDALByStatic>();
            kernel.Bind<ITalkSessionRepositry>().To<TalkSessionRepositryByStaticClass>();
            kernel.Bind<TalkSession>().ToSelf();
            kernel.Bind<MessageRequestContext>().ToSelf();
            kernel.Bind<IPatternManager>().To<PatternManager>();

            Console.WriteLine((new Me.WLF.DALByStatic.FeedBackRepositaryByStatic()).GetType().Assembly);

            string msg = Console.ReadLine();
            MessageHandler handler = new MessageHandler();
            var request = kernel.Get<MessageRequestContext>();

            var response = new MessageReplyContext();

            while (!string.IsNullOrEmpty(msg))
            {
                request = kernel.Get<MessageRequestContext>();
                request.MessageRequest = new RequestTextMessage()
                {
                    From = "wanglifeng",
                    To = "weichat",
                    Content = msg,
                    SentTime = DateTime.Now
                };
                handler.HandleRequest(request, response);

                Console.WriteLine(JsonConvert.SerializeObject(response.ReplyMessage));
                msg = Console.ReadLine();

            }
        }
    }
}
