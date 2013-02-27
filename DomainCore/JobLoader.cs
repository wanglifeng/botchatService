using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class JobLoader
    {
        public IJobRepositary JobRepositary { get; set; }

        public IList<JobSearchResult> Search(JobSearchQuery q)
        {
            return JobRepositary.Search(q);
        }
    }
}
