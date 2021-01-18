using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class InboxController : BaseController
    {
        private readonly IInboxService _inboxService;

        public InboxController(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        [HttpGet]
        // GET: Panel/Inbox
        public ActionResult Index()
        {

            var model = _inboxService.GetAll().ToList();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _inboxService.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InboxModel inboxModel)
        {
            var model = _inboxService.GetById(inboxModel.Id);

            inboxModel.Name = model.Name;

            inboxModel.IP = model.IP;

            inboxModel.DateTime = model.DateTime;

            inboxModel.Messsage = model.Messsage;

            inboxModel.Phone = model.Phone;

            inboxModel.Mail = model.Mail;

            _inboxService.Update(inboxModel);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            InboxModel model = _inboxService.GetById(id);

            if (model != null)
            {
                _inboxService.Remove(model.Id);
            }

            return RedirectToAction("Index");
        }

    }
}