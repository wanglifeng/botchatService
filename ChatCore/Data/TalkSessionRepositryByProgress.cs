using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Data
{
    class TalkSessionRepositryByProgress : ITalkSessionRepositry
    {
        private static List<TalkSession> _Sessions = new List<TalkSession>();

        public TalkSession Get(string From)
        {
            return _Sessions.SingleOrDefault(t => t.From == From);
        }

        public void Save(TalkSession session)
        {
            if (Get(session.From) == null)
            {
                _Sessions.Add(session);
            }
            else
            {
                _Sessions.Remove(Get(session.From));
                _Sessions.Add(session);
            }

        }
    }
}
