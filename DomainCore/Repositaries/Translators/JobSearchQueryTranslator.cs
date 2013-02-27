using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.Repositaries.Translators.Job;
using APICaller.Models;

namespace DomainCore.Repositaries.Translators
{
    class JobSearchQueryTranslator
    {
        private IList<IJobTranslator> _Translators { get; set; }

        public JobSearchQueryTranslator()
        {
            _Translators = new List<IJobTranslator>();

            _Translators.Add(new HostSiteTranslator());
            _Translators.Add(new PageNumberTranslator());
            _Translators.Add(new LocationTranslator());
            _Translators.Add(new KeyWordTranslator());
        }

        public JobSearchRequest Translate(JobSearchQuery query)
        {
            JobSearchRequest request = new JobSearchRequest();
            if (query == null) query = new JobSearchQuery();

            foreach (var t in _Translators)
                t.Translate(query, request);

            return request;
        }

    }
}
