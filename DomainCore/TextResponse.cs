using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DomainCore
{
    [XmlRoot("xml")]
    public class TextResponse
    {
        public String ToUserName { get; set; }
        public String FromUserName { get; set; }
        public long CreateTime { get; set; }
        public String MsgType { get; set; }
        public String Content { get; set; }
        public int FuncFlag { get; set; }
    }
}
