using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore.DB
{
    class User
    {
        public String ID { get; set; }
        public Language Language { get; set; }
    }

    public enum Language
    {
        Chinese,
        English
    }
}
