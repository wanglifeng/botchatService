using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public class TextRequest
    {
        public String ToUserName { get; set; }
        public String FromUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public MsgType MsgType { get; set; }
        public String Content { get; set; }

        public TextRequest(WeiChatRequest req)
        {
            ToUserName = req.ToUserName;
            FromUserName = req.FromUserName;
            CreateTime = new DateTime(req.CreateTime);
            MsgType = MsgType.Text;
            Content = req.Content;
        }
    }

    
}
