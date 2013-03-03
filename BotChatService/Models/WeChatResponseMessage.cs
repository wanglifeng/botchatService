using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace BotChatService.Models
{
    public abstract class WeChatResponseMessage
    {
        public string FromUser { get; set; }
        public String ToUser { get; set; }

        protected abstract void WriteOthers(XmlWriter xw);

        public String ConvertToWeiChatResponse()
        {
            String xmlResponseContent = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                XmlTextWriter xw = new XmlTextWriter(stream, UTF8Encoding.UTF8);
                xw.WriteStartElement("xml");

                xw.WriteStartElement("ToUserName");
                xw.WriteCData(ToUser);
                xw.WriteEndElement();

                xw.WriteStartElement("FromUserName");
                xw.WriteCData(FromUser);
                xw.WriteEndElement();

                xw.WriteStartElement("CreateTime");
                xw.WriteValue((int)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds);
                xw.WriteEndElement();

                WriteOthers(xw);

                xw.WriteStartElement("FuncFlag");
                xw.WriteValue(0);
                xw.WriteEndElement();

                xw.WriteEndElement();

                xw.Flush();

                stream.Position = 0;

                using (StreamReader sr = new StreamReader(stream))
                {
                    xmlResponseContent = sr.ReadToEnd();
                }
            }
            return xmlResponseContent;
        }
    }

    public class WeChatResponseTextMessage : WeChatResponseMessage
    {
        public String Content { get; set; }

        protected override void WriteOthers(XmlWriter xw)
        {
            xw.WriteStartElement("MsgType");
            xw.WriteCData("Text");
            xw.WriteEndElement();

            xw.WriteStartElement("Content");
            xw.WriteCData(Content);
            xw.WriteEndElement();
        }
    }

}