using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainCore;
using DomainCore.Models;

namespace BotChatService.Controllers
{
    public class QuestionAndAnswerController : Controller
    {

        public ActionResult Index()
        {
            var q = (new QuestionRepostaryByDB()).List();
            return View(q);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Question q)
        {
            (new QuestionRepostaryByDB()).Save(q);
            return RedirectToAction("Index");
        }

    }
}
