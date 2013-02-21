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
            session.Request(new Message() { Content = "Search" });
            Console.WriteLine(session.Message.ToString());
            session.Request(new Message() { Content = "User" });
            Console.WriteLine(session.Message.ToString());
            session.Request(new Message() { Content = "1" });
            Console.WriteLine(session.Message.ToString());
            session.Request(new Message() { Content = "王利峰" });
            Console.WriteLine(session.Message.ToString());
            session.Request(new Message() { Content = "1" });
            Console.WriteLine(session.Message.ToString());
        }
    }
}
