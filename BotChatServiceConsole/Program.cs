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
            Console.WriteLine(session.Message.ToString());

            string msgConent = Console.ReadLine();
            while (!String.IsNullOrEmpty(msgConent))
            {
                session.Request(new Message() { Content = msgConent });
                Console.WriteLine(session.Message.ToString());
                msgConent = Console.ReadLine();
            }
        }
    }
}
