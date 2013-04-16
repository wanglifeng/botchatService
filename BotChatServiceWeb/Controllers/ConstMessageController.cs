using Me.WLF.IDAL;
using Me.WLF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace BotChatServiceWeb.Controllers
{
    public class ConstMessageController : BaseController
    {
        private IConstMessageRepositary ConstMessageRepostary;

        public ConstMessageController()
        {
            ConstMessageRepostary = Kernel.Get<IConstMessageRepositary>();
        }

        public ActionResult Index()
        {
            return View(ConstMessageRepostary.List());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ConstMessage message)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ConstMessageRepostary.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(ConstMessage message)
        {
            var msg = ConstMessageRepostary.GetById(message.Id);
            msg.Content = message.Content ?? string.Empty;
            ConstMessageRepostary.Save(msg);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Del(int id)
        {
            ConstMessageRepostary.Del(id);
            return RedirectToAction("Index");
        }
    }
}
