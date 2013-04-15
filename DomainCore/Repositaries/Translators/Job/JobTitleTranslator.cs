using APICaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore.Repositaries.Translators.Job
{
    public class JobTitleTranslator : IJobTranslator
    {
        public void Translate(JobSearchQuery query, JobSearchRequest request)
        {
            if (!String.IsNullOrEmpty(query.KeyWord))
                request.JobTitle = query.KeyWord;
        }
    }
}