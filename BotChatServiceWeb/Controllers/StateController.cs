using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Me.WLF.IDAL;

namespace BotChatServiceWeb.Controllers
{
    public class StateController : BaseController
    {
        
        public ActionResult Index()
        {
            IStateRepostatry repo = Kernel.Get<IStateRepostatry>();
            return View(repo.List());
        }

    }
}
