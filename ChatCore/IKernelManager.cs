using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace ChatCore
{
    public interface IKernelManager
    {
        IKernel GetKernel { get; }
    }
}
