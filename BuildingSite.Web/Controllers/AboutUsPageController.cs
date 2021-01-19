using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class AboutUsPageController : Controller
    {

        private readonly ISiteConstantService _siteConstantService;
      
        private readonly IAboutUsPageService _aboutUsPageService;

        public AboutUsPageController(ISiteConstantService siteConstantService,IAboutUsPageService aboutUsPageService)
        {
            _siteConstantService = siteConstantService;

            _aboutUsPageService = aboutUsPageService;
        }
        // GET: AboutUsPage
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.AboutUsPageModel = _aboutUsPageService.GetById(1);

            return View(model);
        }
    }
}