using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using APICaller.Deserializer;
using APICaller.Serializer;

namespace APICaller.Client
{
    public class RestSharpClient : IClient
    {
        public bool SentAndGetResponse<T1, T2>(string url, Method method, T1 req, out T2 rsp) where T2 : new()
        {
            RestClient client = new RestClient() { BaseUrl = url };
            client.AddHandler("text/xml", new CBAPIDeserializer());
            RestRequest request = new RestRequest()
            {
                Method = (method == Method.GET) ? RestSharp.Method.GET : RestSharp.Method.POST
            };

            switch (request.Method)
            {
                case RestSharp.Method.GET:
                    OnBeforeGet(request, req);
                    break;
                case RestSharp.Method.POST:
                    OnBeforePost(request, req);
                    break;
            }
            
            IRestResponse<T2> response2 = client.Execute<T2>(request);
            
            rsp = response2.Data;
            return true;
        }

        private void OnBeforeGet(RestRequest request, object req)
        {
            foreach (var p in req.GetType().GetProperties())
            {
                if (p.GetValue(req, null) != null)
                    request.AddParameter(p.Name, p.GetValue(req, null));
            }
        }
        private void OnBeforePost(RestRequest request, object req)
        {
            request.XmlSerializer = new CBAPISerializer();
            request.AddBody(req);
        }
    }
}
