using Me.WLF.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BotChatServiceWeb.Models;
using Me.WLF.Model;


namespace BotChatServiceWeb.Controllers
{
    public class StateMessageController : BaseController
    {
        public ActionResult Index(int id)
        {
            ViewBag.StateId = id;
            IStateMessageRepositary repo = Kernel.Get<IStateMessageRepositary>();
            return View(repo.Messages(id));
        }

        [HttpGet]
        public ActionResult Add(int StateId)
        {
            ViewBag.StateId = StateId;
            ViewBag.Languages = new List<SelectListItem>
            {
                 new SelectListItem(){ Text="Chinese", Value="Chinese"},
                 new SelectListItem(){ Text="English", Value="English"}
            };
            return View();
        }

        [HttpPost]
        public ActionResult Add(StateMessageAddModel model)
        {
            IStateMessageRepositary repo = Kernel.Get<IStateMessageRepositary>();
            StateMessage msg = new StateMessage()
            {
                Content = model.Content,
                Language = (Me.WLF.Model.Language)Enum.Parse(typeof(Me.WLF.Model.Language), model.Language, true)
            };
            IStateRepostatry r = Kernel.Get<IStateRepostatry>();
            var s = r.GetById(model.StateId);
            msg.State = s;
            repo.Save(msg);
            return RedirectToAction("Index", new { id = model.StateId });
        }

        [HttpGet]
        public ActionResult Del(int id, int stateId)
        {
            IStateMessageRepositary repo = Kernel.Get<IStateMessageRepositary>();
            repo.Del(id);
            return RedirectToAction("Index", new { id = stateId });
        }
    }
}
