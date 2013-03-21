using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public interface ITalkSessionRepositry
    {
        TalkSession Get(String From);
        void Save(TalkSession session);
    }
}
