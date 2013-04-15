using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCoreConsole
{
    public class TalkSessionRepositryByStaticClass : ITalkSessionRepositry
    {
        public static List<TalkSession> Sessions = new List<TalkSession>();

        public TalkSession Get(string From)
        {
            Console.WriteLine("Get Session {0}", From);
            return Sessions.FirstOrDefault(t => t.From == From);
        }

        public void Save(TalkSession session)
        {
            Remove(session.From);

            Console.WriteLine("Save Session {0}", session.From);

            Sessions.Add(session);
        }

        public void Remove(string from)
        {
            Console.WriteLine("Remove Session {0}", from);

            Sessions.RemoveAll(t => t.From == from);
        }

        public List<TalkSession> AllSessions()
        {
            return Sessions;
        }
    }
}
