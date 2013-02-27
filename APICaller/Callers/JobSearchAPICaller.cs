using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APICaller.Models;

namespace APICaller.Callers
{
    public class JobSearchAPICaller
    {
        public IClient Client { get { return new Client.RestSharpClient(); } }

        public bool Search(String developerKey, JobSearchRequest request, out JobSearchResponse response)
        {
            return Search(developerKey, Client, request, out response);
        }

        private bool Search(string developerKey, IClient client, JobSearchRequest request, out JobSearchResponse response)
        {
            string url = "http://api.careerbuilder.com/v1/jobsearch";
            request.DeveloperKey = developerKey;
            client.SentAndGetResponse<JobSearchRequest, JobSearchResponse>(url, Method.GET, request, out response);
            return true;
        }
    }
}
