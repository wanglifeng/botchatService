using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Me.WLF.Model;
using Newtonsoft.Json;

namespace DomainCore
{
    public class MessageRepositry : IMessageRepositary
    {
        ChatContext context = new ChatContext();

        public void Save(Message msg)
        {
            context.Messages.Add(new Models.Message()
            {
                Content = JsonConvert.SerializeObject(msg),
                From = msg.From,
                To = msg.To,
                CreateDT = msg.SentTime,
                MessageType = msg.GetType().Name
            });
            context.SaveChanges();
        }


        public List<Message> List(string from)
        {
            var msg = context.Messages.Where(t => t.From == from || t.To == from).OrderByDescending(t => t.Id)
                .ToList();
            var messages = new List<Message>();

            if (msg != null)
            {
                foreach (var t in msg)
                {
                    switch (t.MessageType)
                    {
                        case "RequestTextMessage": messages.Add(JsonConvert.DeserializeObject<RequestTextMessage>(t.Content)); break;
                        case "RequestEventMessage": messages.Add(JsonConvert.DeserializeObject<RequestEventMessage>(t.Content)); break;
                        case "ReplyJobResultMessage": messages.Add(JsonConvert.DeserializeObject<ReplyJobResultMessage>(t.Content)); break;
                        case "ReplyTextMessage": messages.Add(JsonConvert.DeserializeObject<ReplyTextMessage>(t.Content)); break;
                        default: break;
                    }
                }
            }
            return messages;
        }
    }
}
