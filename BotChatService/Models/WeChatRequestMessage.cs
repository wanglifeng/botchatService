using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace BotChatService.Models
{
    public abstract class WeChatRequestMessage
    {
        public String ToUserName { get; set; }
        public String FromUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public MsgType MsgType { get; set; }
        public int FuncFlag { get; set; }

        public static WeChatRequestMessage CreateFromXml(String xmlContent)
        {
            if (!String.IsNullOrEmpty(xmlContent))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);
                XmlNode node = doc.SelectSingleNode("/xml/MsgType");
                if (node != null)
                {
                    switch (node.InnerText)
                    {
                        case "text":
                            return new WeChatRequestTextMessage(doc);
                    }
                }
            }
            return null;
        }
    }

    public class WeChatRequestTextMessage : WeChatRequestMessage
    {
        public String Content { get; set; }

        public WeChatRequestTextMessage() { }

        public WeChatRequestTextMessage(XmlDocument doc)
        {
            FromUserName = doc.SelectSingleNode("/xml/FromUserName").InnerText;
            ToUserName = doc.SelectSingleNode("/xml/ToUserName").InnerText;
            MsgType = MsgType.Text;
            double timeStamp = double.Parse(doc.SelectSingleNode("/xml/CreateTime").InnerText);
            CreateTime = (new DateTime(1970, 1, 1).AddSeconds(timeStamp).ToLocalTime());
            Content = doc.SelectSingleNode("/xml/Content").InnerText;
        }
    }

    public enum MsgType
    {
        Text,
        Pic,
        Locaton
    }
}