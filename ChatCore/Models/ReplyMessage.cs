using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ChatCore.Models
{
    public abstract class ReplyMessage
    {
        public String From { get; set; }
        public String To { get; set; }
        public DateTime CreateDT { get; set; }
    }

    public class ReplyTextMessage : ReplyMessage
    {
        public String Content { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ReplyJobResultMessage : ReplyMessage
    {
        public List<JobResult> Results { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
