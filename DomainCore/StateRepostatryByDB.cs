using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace DomainCore
{
    public class StateRepostatryByDB : IStateRepostatry
    {
        private object LockObj = new object();

        public void Save(State state)
        {
            using (ChatContext c = new ChatContext())
            {
                var s = c.State.SingleOrDefault(t => t.TypeName == state.TypeName);
                if (s == null)
                {
                    lock (LockObj)
                    {
                        s = c.State.SingleOrDefault(t => t.TypeName == state.TypeName);
                        if (s == null)
                        {
                            c.State.Add((Models.State)state);
                        }
                    }
                }
                else
                {
                    s.Description = state.Description;
                    s.Name = state.Name;
                }
                c.SaveChanges();
            }
        }

        public List<State> List()
        {
            using (ChatContext context = new ChatContext())
            {
                using (ChatContext c = new ChatContext())
                {
                    var s = new List<State>();
                    c.State.ToList().ForEach(t =>
                    {
                        s.Add((State)t);
                    });
                    return s;
                }
            }
        }


        public State GetById(int id)
        {
            using (ChatContext c = new ChatContext())
            {
                var s = c.State.SingleOrDefault(t => t.Id == id);
                if (s != null)
                    return (Me.WLF.Model.State)s;

                return null;
            }
        }
    }
}
