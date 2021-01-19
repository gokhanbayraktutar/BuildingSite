using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IAboutUsPageService _aboutUsPageService;

        private readonly IOurServiceService _ourServiceService;

        private readonly ISliderService _sliderService;

        private readonly IProjectService _projectService;

        private readonly IReferencesService _referencesService;
        
        private readonly INewsService _newsService;

        private readonly IContactPageService _contactPageService;

        public HomeController(ISiteConstantService siteConstantService, IAboutUsPageService aboutUsPageService, IOurServiceService ourServiceService , ISliderService sliderService,  IProjectService projectService, IReferencesService referencesService, INewsService newsService,IContactPageService contactPageService)
        {
            _siteConstantService = siteConstantService;

            _aboutUsPageService = aboutUsPageService;

            _ourServiceService = ourServiceService;

            _sliderService = sliderService;

            _projectService = projectService;

            _referencesService = referencesService;

            _newsService = newsService;

            _contactPageService = contactPageService;

        }

        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.sliderModels = _sliderService.GetAll().Where(x=>x.Active == true).ToList();

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.AboutUsPageModel = _aboutUsPageService.GetById(1);

            model.newsModels = _newsService.GetAll().OrderBy(x=>x.Date).Take(3).ToList();

            return View(model);
        }

        public ActionResult Mail()
        {
            var model = _aboutUsPageService.GetById(1);

            return Content(model.Mail);
        }

    }
}