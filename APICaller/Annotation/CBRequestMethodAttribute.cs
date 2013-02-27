using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APICaller.Annotation
{
    public class CBRequestMethodAttribute : Attribute
    {
        private readonly RequestMethods _METHOD;

        public CBRequestMethodAttribute(RequestMethods method)
        {
            _METHOD = method;
        }

        public RequestMethods Method
        {
            get
            {
                return _METHOD;
            }
        }

        public enum RequestMethods
        {
            GET,
            POST
        }
    }
}
