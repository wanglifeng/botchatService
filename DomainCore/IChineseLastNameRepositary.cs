using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public interface IChineseLastNameRepositary
    {
        List<String> ValidChineseLastNames { get; }
    }
}
