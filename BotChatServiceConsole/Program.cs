using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCoreConsole
{
    public class Program
    {
        public static void Main(String[] args)
        {
            TalkSession session = new TalkSession("wanglifeng");
            //Console.WriteLine(session.Message.ToString());

            string msgConent = Console.ReadLine();
            while (!String.IsNullOrEmpty(msgConent))
            {
                session.Request(new Message() { From = "wanglifeng", To = "ROBOT", SentTime = DateTime.Now, Content = msgConent });
                Console.WriteLine(session.ReplyMessage.ToString());
                msgConent = Console.ReadLine();
            }
        }
    }
}
