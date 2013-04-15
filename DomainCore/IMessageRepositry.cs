using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.Models;

namespace DomainCore
{
    interface IMessageRepositry
    {
        void Save(Message message);
        List<Message> List();

    }
}
