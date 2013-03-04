using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainCore;

namespace BotChatService.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            IUserRepositary repo = new UserRepositaryByDB();
            return View(repo.List());
        }

    }
}
