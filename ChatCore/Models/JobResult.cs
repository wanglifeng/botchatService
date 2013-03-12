using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ChatCore.Models
{
    public class JobResult
    {
        public String DID { get; set; }
        public String Title { get; set; }
        public String CompanyName { get; set; }

        public String CompanyImageURL { get; set; }

        public String JobDetailsURL { get; set; }
        public String Description { get; set; }
    }
}
