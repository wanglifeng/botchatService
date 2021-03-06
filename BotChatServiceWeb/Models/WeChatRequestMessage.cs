﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

using Me.WLF.Model;

namespace BotChatServiceWeb.Models
{
    public abstract class WeChatRequestMessage
    {
        public String ToUserName { get; set; }
        public String FromUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public MsgType MsgType { get; set; }
        public int FuncFlag { get; set; }


        protected WeChatRequestMessage(XmlDocument doc)
        {
            FromUserName = doc.SelectSingleNode("/xml/FromUserName").InnerText;
            ToUserName = doc.SelectSingleNode("/xml/ToUserName").InnerText;
            MsgType = MsgType.Text;
            double timeStamp = double.Parse(doc.SelectSingleNode("/xml/CreateTime").InnerText);
            CreateTime = (new DateTime(1970, 1, 1).AddSeconds(timeStamp).ToLocalTime());
        }

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
                        case "event":
                            return new WeChatRequestEventMessage(doc);
                    }
                }
            }
            return null;
        }

        public static explicit operator RequestMessage(WeChatRequestMessage message)
        {
            if (message is WeChatRequestTextMessage)
            {
                var m = message as WeChatRequestTextMessage;
                return new RequestTextMessage()
                {
                    Content = m.Content,
                    From = m.FromUserName,
                    MsgType = RequestMessage.MessageType.text,
                    SentTime = m.CreateTime,
                    To = m.ToUserName,
                    ClientId = "WeChat"
                };
            }
            else if (message is WeChatRequestEventMessage)
            {
                var m = message as WeChatRequestEventMessage;
                return new RequestEventMessage()
                {
                    Event = m.Event,
                    From = m.FromUserName,
                    MsgType = RequestMessage.MessageType.text,
                    SentTime = m.CreateTime,
                    To = m.ToUserName,
                    ClientId = "WeChat"
                };
            }
            return null;
        }
    }

    public class WeChatRequestTextMessage : WeChatRequestMessage
    {
        public String Content { get; set; }

        public WeChatRequestTextMessage(XmlDocument doc)
            : base(doc)
        {
            FromUserName = doc.SelectSingleNode("/xml/FromUserName").InnerText;
            ToUserName = doc.SelectSingleNode("/xml/ToUserName").InnerText;
            MsgType = MsgType.Text;
            double timeStamp = double.Parse(doc.SelectSingleNode("/xml/CreateTime").InnerText);
            CreateTime = (new DateTime(1970, 1, 1).AddSeconds(timeStamp).ToLocalTime());
            Content = doc.SelectSingleNode("/xml/Content").InnerText;
        }
    }

    public class WeChatRequestEventMessage : WeChatRequestMessage
    {
        public String EventKey { get; set; }
        public String Event { get; set; }

        public WeChatRequestEventMessage(XmlDocument doc)
            : base(doc)
        {

            Event = doc.SelectSingleNode("/xml/Event").InnerText;
            EventKey = doc.SelectSingleNode("/xml/EventKey").InnerText;
        }
    }

    public enum MsgType
    {
        Text,
        Pic,
        Locaton,
        Event
    }
}