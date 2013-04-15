using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.WLF.Model
{
    public class State
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String TypeName { get; set; }
        public String Description { get; set; }

        public List<StateMessage> Messages { get; set; }
    }
}
