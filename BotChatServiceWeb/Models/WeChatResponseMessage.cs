using ChatCore.Models;
using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace BotChatServiceWeb.Models
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

        public static WeChatResponseMessage GetMessage(ReplyMessage message)
        {
            if (message is ReplyTextMessage)
            {
                return new WeChatResponseTextMessage()
                {
                    FromUser = message.From,
                    ToUser = message.To,
                    Content = (message as ReplyTextMessage).Content
                };
            }
            else if (message is ReplyJobResultMessage)
            {
                return new WeChatJobResultsResponseMessage()
                {
                    FromUser = message.From,
                    ToUser = message.To,
                    Results = (message as ReplyJobResultMessage).Results
                };
            }
            return null;
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

    public class WeChatJobResultsResponseMessage : WeChatResponseMessage
    {
        public List<JobResult> Results { get; set; }

        protected override void WriteOthers(XmlWriter xw)
        {
            xw.WriteStartElement("MsgType");
            xw.WriteCData("news");
            xw.WriteEndElement();

            xw.WriteStartElement("ArticleCount");
            xw.WriteValue(Results.Count);
            xw.WriteEndElement();

            xw.WriteStartElement("Articles");

            Results = Results.OrderByDescending(t => t.CompanyImageURL).ToList();

            foreach (var t in Results)
            {
                xw.WriteStartElement("item");

                xw.WriteStartElement("Title");
                xw.WriteCData(t.Title);
                xw.WriteEndElement();

                xw.WriteStartElement("Description");
                xw.WriteCData(t.Description);
                xw.WriteEndElement();

                xw.WriteStartElement("PicUrl");
                xw.WriteCData(t.CompanyImageURL);
                xw.WriteEndElement();

                xw.WriteStartElement("Url");
                if (t.JobDetailsURL.IndexOf("?") > -1)
                {
                    xw.WriteCData(t.JobDetailsURL + "&siteid=wechat");
                }
                else
                {
                    xw.WriteCData(t.JobDetailsURL + "?siteid=wechat");
                }
                xw.WriteEndElement();

                xw.WriteEndElement();
            }

            xw.WriteEndElement();
        }
    }

}