using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace DomainCore
{
    public class ConstMessageRepositaryByDB : IConstMessageRepositary
    {
        private object Lockobject = new object();
        private ChatContext Context = new ChatContext();

        public string GetMessage(string format, Language language, params string[] args)
        {
            var l = language.ToString();
            var msg = Context.ConstMessages.SingleOrDefault(t => t.Language == l && t.Format == format);
            if (msg == null)
            {
                var content = string.Format("format:{0}, Language:{1} NOT FOUND", format, language);
                Save(new ConstMessage() { Language = l, Format = format, Content = content });
                return content;
            }
            else
            {
                return string.Format(msg.Content, args);
            }
        }

        public void Save(ConstMessage message)
        {
            var msg = Context.ConstMessages.SingleOrDefault(t => t.Language == message.Language && t.Format == message.Format);
            if (msg == null)
            {
                lock (Lockobject)
                {
                    msg = Context.ConstMessages.SingleOrDefault(t => t.Language == message.Language && t.Format == message.Format);
                    if (msg == null)
                    {
                        msg = new Models.ConstMessage()
                        {
                            Content = message.Content,
                            Format = message.Format,
                            Language = message.Language
                        };
                        Context.ConstMessages.Add(msg);
                    }
                }
            }
            else
            {
                msg.Content = message.Content;
            }
            Context.SaveChanges();
        }


        public List<ConstMessage> List()
        {
            using (ChatContext c = new ChatContext())
            {
                return c.ConstMessages.ToList().Select(t =>
                    {
                        return new ConstMessage()
                        {
                            Id = t.Id,
                            Content = t.Content,
                            Format = t.Format,
                            Language = t.Language
                        };
                    }).ToList();
            }
        }




        public void Del(int id)
        {
            var msg = Context.ConstMessages.SingleOrDefault(t => t.Id == id);
            if (msg != null)
                Context.ConstMessages.Remove(msg);
            Context.SaveChanges();
        }


        public ConstMessage GetById(int id)
        {
            var msg = Context.ConstMessages.SingleOrDefault(t => t.Id == id);
            if (msg != null)
            {
                return new ConstMessage()
                {
                    Id = msg.Id,
                    Content = msg.Content,
                    Language = msg.Language,
                    Format = msg.Format
                };
            }
            return null;
        }
    }
}
