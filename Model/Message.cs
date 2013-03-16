using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.Model
{
    public abstract class Message
    {
        public String From { get; set; }
        public String To { get; set; }
        public DateTime SentTime { get; set; }

    }
}
