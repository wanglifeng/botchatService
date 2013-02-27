using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore.Filters
{
    public interface IFilter
    {
        bool Filters(String userId, String content, out String result);
    }
}
