using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotChatServiceWeb
{
    public class TalkSessionRepositryByStaticClass : ITalkSessionRepositry
    {
        public static List<TalkSession> Sessions = new List<TalkSession>();

        public TalkSession Get(string From)
        {
            return Sessions.FirstOrDefault(t => t.From == From);
        }

        public void Save(TalkSession session)
        {
            Remove(session.From);

            Sessions.Add(session);
        }

        public void Remove(string from)
        {
            Sessions.RemoveAll(t => t.From == from);
        }


        public List<TalkSession> AllSessions()
        {
            return Sessions;
        }
    }
}