using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaller.Models;

namespace DomainCore.Repositaries.Translators.Job
{
    interface IJobTranslator
    {
        void Translate(JobSearchQuery query, JobSearchRequest request);
    }
}
