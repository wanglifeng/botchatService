using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChatCore.States;

namespace ChatCore
{
    public class Message
    {
        public String From { get; set; }
        public String To { get; set; }
        public DateTime SentTime { get; set; }
        public String Content { get; set; }

        public override string ToString()
        {
            return String.Format("From:{0}\nTo:{1}\nContent:{2}\nTime{3}\n==========================", From, To, Content, SentTime);
        }

    }
}
