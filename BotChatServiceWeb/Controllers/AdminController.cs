using BotChatServiceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Me.WLF.IDAL;
using ChatCore;

namespace BotChatServiceWeb.Controllers
{
    public class AdminController : Controller
    {
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
                var repo = KernelManager.Kernel.Get<IAdminRepositary>();
                if (repo.GetByUserNameAndPassword(model.UserName, model.Password) != null)
                {
                    Session["CurrentUser"] = repo.GetByUserNameAndPassword(model.UserName, model.Password);
                    return Redirect("Main");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Username or PassWord is incorrect");
                }
            }
            return View(model);
        }

    }
}
