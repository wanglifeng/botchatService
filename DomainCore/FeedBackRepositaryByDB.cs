using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;

namespace DomainCore
{
    public class FeedBackRepositaryByDB : IFeedBackRepositary
    {
        public List<FeedBack> List()
        {
            using (ChatContext c = new ChatContext())
            {
                var feedbacks = new List<FeedBack>();
                c.FeedBacks.ToList().ForEach(t =>
                {
                    feedbacks.Add((FeedBack)t);
                });
                return feedbacks;
            }
        }

        public void Del(int id)
        {
            using (ChatContext c = new ChatContext())
            {
                var u = c.FeedBacks.SingleOrDefault(t => t.Id == id);
                if (u != null)
                    c.FeedBacks.Remove(u);

                c.SaveChanges();
            }
        }

        public void Save(FeedBack feedback)
        {
            using (ChatContext c = new ChatContext())
            {
                c.FeedBacks.Add((Models.FeedBack)feedback);
                c.SaveChanges();
            }
        }
    }
}
