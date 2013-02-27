using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    interface ICacheObject
    {
        String GenearteCacheKey();
    }
}
