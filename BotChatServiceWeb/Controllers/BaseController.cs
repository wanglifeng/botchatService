using ChatCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotChatServiceWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IKernel Kernel = KernelManager.Kernel;

    }
}
