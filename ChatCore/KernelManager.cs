using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore
{
    public static class KernelManager
    {
        private static IKernel _Kernel;
        private static object _LockObj = new object();

        public static IKernel Kernel
        {
            get
            {
                if (_Kernel == null)
                {
                    lock (_LockObj)
                    {
                        if (_Kernel == null)
                        {
                            var managerImplClass = System.Configuration.ConfigurationManager.AppSettings["IKernelManager"];
                            IKernelManager kernel = Activator.CreateInstance(Type.GetType(managerImplClass)) as IKernelManager;
                            if (kernel != null)
                                _Kernel = kernel.GetKernel;
                        }
                    }
                }
                return _Kernel;
            }
        }

    }
}
