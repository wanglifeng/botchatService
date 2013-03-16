using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.IDAL
{
    public interface IFeedBackRepositary
    {
        List<FeedBack> List();
        void Del(int id);
        void Save(FeedBack feedback);
    }
}
