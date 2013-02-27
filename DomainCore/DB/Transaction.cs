using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore.DB
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public String UserId { get; set; }
        public string KeyWord { get; set; }
        public string Location { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        New,
        KeyWordSet,
        LocationSet,
        Done
    }
}
