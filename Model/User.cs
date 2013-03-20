using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.Model
{
    public class User
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String ClientId { get; set; }
        public String Location { get; set; }
        public String Name { get; set; }
        public String Degree { get; set; }
        public Language Language { get; set; }
    }

    public enum Language
    {
        None,
        Chinese,
        English
    }
}
