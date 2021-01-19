using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class ContactPageController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IContactPageService _contactPageService;

        private readonly IInboxService _inboxService;

        public ContactPageController(ISiteConstantService siteConstantService, IContactPageService contactPageService, IInboxService inboxService)
        {
            _siteConstantService = siteConstantService;

            _contactPageService = contactPageService;

            _inboxService = inboxService;
        }


        // GET: Contact
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ContactPageModel = _contactPageService.GetById(1);

            return View(model);
        }

        [HttpPost]
        public ActionResult SendMessage(InboxModel inboxModel)
        {
           
                if(inboxModel.Name != null && inboxModel.Phone != null && inboxModel.Mail != null && inboxModel.Messsage != null)
                {
                    inboxModel.IP = System.Web.HttpContext.Current.Request.UserHostAddress;

                    inboxModel.Read = false;

                    inboxModel.DateTime = DateTime.Now;

                    _inboxService.Add(inboxModel);

                    ViewBag.Success = "Mesaj Gönderildi!";

                }

                else
                {
                    ViewBag.Error = "Boş Alan Bırakmayınız!";
                }
            
            
                ViewModel model = new ViewModel();

                model.SiteConstantModel = _siteConstantService.GetById(6);

                model.ContactPageModel = _contactPageService.GetById(1);

                return View("Index",model);
        }
    }
}