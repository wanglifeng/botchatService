using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace APICaller.Models
{
    #region "Search"
    public class JobSearchRequest
    {
        public string DeveloperKey { get; set; }
        public int PageNumber { get; set; }
        public int PerPage { get; set; }
        public string HostSite { get; set; }
        public string Keywords { get; set; }
        public String Location { get; set; }
    }

    [XmlRoot("ResponseJobSearch")]
    public class JobSearchResponse
    {
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<JobSearchResult> Results { get; set; }

        public class JobSearchResult
        {
            public String DID { get; set; }
            public String Company { get; set; }
            public String JobTitle { get; set; }
            public String DescriptionTeaser { get; set; }
            public string JobDetailURL { get; set; }
            public String Location { get; set; }
            public String PostedDate { get; set; }
        }
    }
    #endregion
}
