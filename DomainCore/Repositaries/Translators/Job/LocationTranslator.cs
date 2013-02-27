using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaller.Models;

namespace DomainCore.Repositaries.Translators.Job
{
    public class LocationTranslator : IJobTranslator
    {
        public void Translate(JobSearchQuery query, JobSearchRequest request)
        {
            if (!String.IsNullOrEmpty(query.Location))
                request.Location = query.Location;
        }
    }
}
