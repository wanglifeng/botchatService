using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APICaller.Annotation
{
    public class CBCustomAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CBHasCustomValuesAttribute : Attribute
    {
    }
}
