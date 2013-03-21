using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainCore;
using Me.WLF.IDAL;
using Me.WLF.Model;

namespace BotChatService.Controllers
{
    public class ChineseLastNameController : Controller
    {
        public ActionResult Index()
        {
            IChineseLastNameRepositary repo = new ChineseLastNameRepositaryByDB();
            return View(repo.List());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ChineseLastName model)
        {
            IChineseLastNameRepositary repo = new ChineseLastNameRepositaryByDB();
            repo.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Del(int id)
        {
            IChineseLastNameRepositary repo = new ChineseLastNameRepositaryByDB();
            repo.Del(id);
            return RedirectToAction("Index");
        }
    }
}
