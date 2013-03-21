using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.IDAL;
using Me.WLF.Model;

namespace Me.WLF.DALByStatic
{
    public class FeedBackRepositaryByStatic : IFeedBackRepositary
    {
        private List<FeedBack> _FeedBacks = new List<FeedBack>();

        public List<FeedBack> List()
        {
            return _FeedBacks;
        }

        public void Del(int id)
        {
            _FeedBacks.RemoveAll(t => t.Id == id);
        }

        public void Save(FeedBack feedback)
        {
            Console.WriteLine("Saving feedback");
            _FeedBacks.Add(feedback);
            Console.WriteLine("Saved FeedBack");
        }
    }
}
