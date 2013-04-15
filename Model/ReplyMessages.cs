using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.Model
{
    public abstract class ReplyMessage : Message { }

    public class ReplyTextMessage : ReplyMessage
    {
        public String Content { get; set; }
    }

    public class ReplyJobResultMessage : ReplyMessage
    {
        public List<JobResult> Results { get; set; }
    }
}
