using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaller.Models;

namespace DomainCore.Repositaries.Translators.Job
{
    class PageNumberTranslator : IJobTranslator
    {
        public void Translate(JobSearchQuery query, JobSearchRequest request)
        {
            if (query.PageSize <= 0)
            {
                query.PageSize = 25;
                request.PerPage = 25;
            }
            else
            {
                request.PerPage = query.PageSize;
            }

            if (query.StartIndex == 0)
                request.PageNumber = 1;
            else
                request.PageNumber = query.StartIndex / query.PageSize;

        }
    }
}
