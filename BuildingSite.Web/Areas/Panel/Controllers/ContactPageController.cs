using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class ContactPageController : BaseController
    {
        private readonly IContactPageService _contactPageService;

        public ContactPageController(IContactPageService contactPageService)
        {
            _contactPageService = contactPageService;
        }

        // GET: Panel/ContactPage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ContactPageModel model = _contactPageService.GetById(id);

            return View(model);

        }



        public ActionResult Edit(ContactPageModel contactPageModel)
        {

             _contactPageService.Update(contactPageModel);

            return RedirectToAction("Edit");
        }
    }
}