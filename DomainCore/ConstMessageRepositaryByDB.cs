using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class ConstMessageRepositaryByDB : IConstMessageRepositary
    {

        public string GetMessage(string format, Me.WLF.Model.Language language)
        {
            using (ChatContext c = new ChatContext())
            {
                var m = 
            }
        }

        public void Save(Me.WLF.Model.ConstMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
