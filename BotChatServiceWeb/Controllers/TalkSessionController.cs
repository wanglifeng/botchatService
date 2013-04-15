using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ChatCore;

namespace BotChatServiceWeb.Controllers
{
    public class TalkSessionController : BaseController
    {

        public ActionResult Index()
        {
            ITalkSessionRepositry sessions = Kernel.Get<ITalkSessionRepositry>();
            return View(sessions.AllSessions());
        }

        public ActionResult Del(string from)
        {
            ITalkSessionRepositry sessions = Kernel.Get<ITalkSessionRepositry>();
            sessions.Remove(from);
            return RedirectToAction("Index");
        }

    }
}
