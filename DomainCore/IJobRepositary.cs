using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public interface IJobRepositary
    {
        IList<JobSearchResult> Search(JobSearchQuery query);
    }
}
