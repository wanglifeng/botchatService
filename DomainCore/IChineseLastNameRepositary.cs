using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.Models;

namespace DomainCore
{
    public interface IChineseLastNameRepositary
    {
        List<String> ValidChineseLastNames { get; }

        List<ChineseLastName> List();

        void Save(ChineseLastName name);
    }
}
