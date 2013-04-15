using DomainCore.Models;
using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class StateMessageRepositaryByDB : IStateMessageRepositary
    {
        public List<Me.WLF.Model.StateMessage> Messages(object state, Me.WLF.Model.Language language)
        {
            using (ChatContext c = new ChatContext())
            {
                var typename = state.GetType().FullName;

                var s = c.State.SingleOrDefault(t => t.TypeName == typename);
                if (s == null)
                {
                    s = (State)(new Me.WLF.Model.State() { TypeName = state.GetType().FullName });
                    c.State.Add(s);
                    c.SaveChanges();
                    return new List<Me.WLF.Model.StateMessage>()
                    {
                         new Me.WLF.Model.StateMessage(){ Content="No Message In"+state.GetType().FullName+" Language:"+language}
                    };
                }
                else
                {
                    List<Me.WLF.Model.StateMessage> msgs = new List<Me.WLF.Model.StateMessage>();
                    var l = language.ToString();
                    var m = c.StateMessages.Where(t => t.State.Id == s.Id && t.Language == l).ToList();
                    if (m != null && m.Count > 0)
                    {
                        m.ForEach(t => msgs.Add((Me.WLF.Model.StateMessage)t));
                    }
                    else
                    {
                        msgs.Add(new Me.WLF.Model.StateMessage() { Content = "No Message In" + state.GetType().FullName + " Language:" + language });
                    }
                    return msgs;
                }
            }
        }


        public List<Me.WLF.Model.StateMessage> Messages(int stateId)
        {
            using (ChatContext c = new ChatContext())
            {
                var state = c.State.SingleOrDefault(t => t.Id == stateId);
                if (state != null)
                {
                    List<Me.WLF.Model.StateMessage> msgs = new List<Me.WLF.Model.StateMessage>();
                    c.StateMessages.Where(t => t.State.Id == stateId).ToList().ForEach(t =>
                        {
                            msgs.Add((Me.WLF.Model.StateMessage)t);
                        });
                    return msgs;
                }
                return new List<Me.WLF.Model.StateMessage>();
            }
        }


        public void Save(Me.WLF.Model.StateMessage msg)
        {
            using (ChatContext c = new ChatContext())
            {
                var m = c.StateMessages.SingleOrDefault(t => t.Id == msg.Id && t.State.Id == msg.State.Id);
                if (m == null)
                {
                    var s = new StateMessage() { Content = msg.Content, Language = msg.Language.ToString() };
                    s.State = c.State.SingleOrDefault(t => t.Id == msg.State.Id);
                    c.StateMessages.Add(s);
                }
                else
                {
                    m.Content = msg.Content;
                    m.Language = msg.Language.ToString();
                }
                c.SaveChanges();
            }
        }


        public void Del(int id)
        {
            using (ChatContext c = new ChatContext())
            {
                var s = c.StateMessages.SingleOrDefault(t => t.Id == id);
                if (s != null)
                    c.StateMessages.Remove(s);

                c.SaveChanges();
            }
        }
    }
}
