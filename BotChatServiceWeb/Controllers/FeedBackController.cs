using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Me.WLF.IDAL;
using DomainCore;

namespace BotChatServiceWeb.Controllers
{
    public class FeedBackController : Controller
    {

        public IFeedBackRepositary FeedBackRepositary { get; set; }

        public ActionResult Index()
        {
            FeedBackRepositary = new FeedBackRepositaryByDB();
            return View(FeedBackRepositary.List());
        }
    }
}
