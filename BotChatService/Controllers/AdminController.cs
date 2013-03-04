using BotChatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotChatService.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "CareerBuilder" && model.Password == "C@reerBuilder")
                {
                    return RedirectToAction("Main", "Manage");
                }
            }
            return View(model);
        }

    }
}
