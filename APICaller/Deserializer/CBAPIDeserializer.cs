using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using RestSharp;

namespace APICaller.Deserializer
{
    class CBAPIDeserializer : IDeserializer
    {
        private DotNetXmlDeserializer _deserializer = new DotNetXmlDeserializer();

        public String Dateformat { get; set; }
        public T Deserialize<T>(IRestResponse response)
        {
            T t = _deserializer.Deserialize<T>(response);
            return t;
        }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string DateFormat { get; set; }
    }
}
