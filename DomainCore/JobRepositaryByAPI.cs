using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaller.Callers;
using DomainCore.Repositaries.Translators;
using APICaller.Models;

namespace DomainCore
{
    public class JobRepositaryByAPI : IJobRepositary
    {

        public JobSearchAPICaller JobSearchAPICaller { get { return new JobSearchAPICaller(); } }

        public IList<JobSearchResult> Search(JobSearchQuery query)
        {
            
                return SearchFromAPI(query);

        }

        private IList<JobSearchResult> SearchFromAPI(JobSearchQuery query)
        {
            JobSearchQueryTranslator translator = new JobSearchQueryTranslator();
            JobSearchRequest req = translator.Translate(query);

            JobSearchResponse rsp = null;

            JobSearchAPICaller.Search("WD1B37Z74Y7BL07ZM89B", req, out rsp);

            return rsp.Results.Select(t => new JobSearchResult()
            {
                JobTitle = t.JobTitle,
                Detail = t.DescriptionTeaser,
                Company = t.Company,
                DID = t.DID,
                Location = t.Location,
                PostedDate = DateTime.Parse(t.PostedDate)

            }).ToList();
        }
    }
}
