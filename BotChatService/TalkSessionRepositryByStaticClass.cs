using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotChatService
{
    public class TalkSessionRepositryByStaticClass : ITalkSessionRepositry
    {
        public static List<TalkSession> Sessions = new List<TalkSession>();

        public TalkSession Get(string From)
        {
            return Sessions.SingleOrDefault(t => t.From == From);
        }

        public void Save(TalkSession session)
        {
            Sessions.Add(session);
        }
    }
}