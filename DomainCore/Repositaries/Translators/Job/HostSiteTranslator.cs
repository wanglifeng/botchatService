using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaller.Models;

namespace DomainCore.Repositaries.Translators.Job
{
    class HostSiteTranslator : IJobTranslator
    {
        public void Translate(JobSearchQuery query, JobSearchRequest request)
        {
            request.HostSite = "CN";
        }
    }
}
