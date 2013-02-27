using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class JobSearchResult
    {
        public string JobTitle { get; set; }
        public string Detail { get; set; }
        public String DID { get; set; }
        public String Company { get; set; }
        public String Location { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
