using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
   public class SearchTransaction
    {
       public String UserID { get; set; }
       public JobSearchQuery Query { get; set; }

    }

   public class JobSearchQuery : ICacheObject
   {
       public string KeyWord { get; set; }
       public String Location { get; set; }
       public int StartIndex { get; set; }
       public int PageSize { get; set; }

       public string GenearteCacheKey()
       {
           StringBuilder sb = new StringBuilder();
           sb.AppendFormat("{0}={1}&", "KeyWord", KeyWord);
           sb.AppendFormat("{0}={1}&", "Location", Location);
           sb.AppendFormat("{0}={1}&", "StartIndex", StartIndex);
           sb.AppendFormat("{0}={1}&", "PageSize", PageSize);
           return sb.ToString();
       }
   }
}
