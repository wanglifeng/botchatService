using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.IDAL;
using Me.WLF.Model;

namespace Me.WLF.DALByStatic
{
    class MessageRepositaryByStatic:IMessageRepositary
    {
        private List<Message> Messages = new List<Message>();

        public void Save(Message msg)
        {
            Console.WriteLine("Saving Msg");
            Messages.Add(msg);
            Console.WriteLine("Saved Msg");
        }
    }
}
