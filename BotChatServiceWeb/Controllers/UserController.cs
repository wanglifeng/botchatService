﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainCore;
using Me.WLF.IDAL;
using Ninject;

namespace BotChatServiceWeb.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            IUserRepositary repo = new UserRepositaryByDB();
            return View(repo.List());
        }

        public ActionResult Del(int id)
        {
            IUserRepositary repo = new UserRepositaryByDB();
            repo.Del(id);
            return RedirectToAction("Index");
        }

        public ActionResult Messages(string userId)
        {
            IMessageRepositary repo = Kernel.Get<IMessageRepositary>();
            return View(repo.List(userId));
        }

        

    }
}
