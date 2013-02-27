using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APICaller
{
    public interface IClient
    {


        bool SentAndGetResponse<T1, T2>(string url, Method method, T1 req, out T2 rsp) where T2 : new();
    }

    public enum Method
    {
        GET,
        POST
    }
}
