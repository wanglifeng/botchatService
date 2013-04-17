using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using DomainCore.Repositaries.Translators;
using APICaller.Models;
using System.Text.RegularExpressions;

namespace DomainCore
{
    public class JobRepositaryByBaiJob : IJobRepositary
    {
        public IList<JobSearchResult> Search(JobSearchQuery query)
        {
            JobSearchQueryTranslator translator = new JobSearchQueryTranslator();
            JobSearchRequest req = translator.Translate(query);

            List<JobSearchResult> results = new List<JobSearchResult>();
            IRestClient client = new RestClient() { BaseUrl = "http://search.baijob.com" };
            var request = new RestRequest()
            {
                Resource = "/"
            };
            request.AddParameter("wd", req.Keywords);
            request.AddParameter("job_cit", req.Location);
            request.AddParameter("rn", req.PerPage);
            request.AddParameter("pn", req.PageNumber);
            var response = client.Execute(request);
            var matches = Regex.Matches(response.Content, "<a href=\"http://zhiwei.baijob.com/\\d+\" [\\w\"=()（） ,:\\/.><-]+", RegexOptions.IgnoreCase);
            for (int i = 0; i < matches.Count; i = i + 2)
            {
                var str = matches[i].Value;
                JobSearchResult r = new JobSearchResult()
                {
                    JobDetailsURL = Regex.Match(str, "http://zhiwei.baijob.com/\\d+", RegexOptions.IgnoreCase).Value,
                    JobTitle = Regex.Match(str, "(?<=title=\")[^\"]+(?=\")").Value
                };
                results.Add(r);
            }
            return results;

        }
    }
}
