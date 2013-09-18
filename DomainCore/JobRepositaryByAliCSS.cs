using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliCSSSDK.Callers;
using AliCSSSDK.Models;
using AliCSSSDK;

namespace DomainCore
{
    public class JobRepositaryByAliCSS : IJobRepositary
    {
        public IList<JobSearchResult> Search(JobSearchQuery query)
        {
            AliCSSCaller caller = new AliCSSCaller();
            var searchParams = new Search.SearchParams();
            searchParams.Query.Add("cat", query.Location);
            searchParams.Query.Add("era", query.KeyWord);
            searchParams.page = query.StartIndex / query.PageSize;
            searchParams.page_size = query.PageSize;

            var results = caller.Search.DoSearch<Novel>("campusjobs", searchParams);

            if (results != null)
                return results.result.items.Select(t => new JobSearchResult()
                {
                    JobTitle = t.era,
                    JobDetailsURL = t.url
                }).ToList();
            return null;
        }
    }
}
