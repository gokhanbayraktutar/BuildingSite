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

        private readonly IProject_PictureService _project_PictureService;

        public HomeController(ISiteConstantService siteConstantService, IAboutUsPageService aboutUsPageService, IOurServiceService ourServiceService , ISliderService sliderService,  IProjectService projectService, IReferencesService referencesService, INewsService newsService,IContactPageService contactPageService, IProject_PictureService project_PictureService)
        {
            _siteConstantService = siteConstantService;

            _aboutUsPageService = aboutUsPageService;

            _ourServiceService = ourServiceService;

            _sliderService = sliderService;

            _projectService = projectService;

            _referencesService = referencesService;

            _newsService = newsService;

            _contactPageService = contactPageService;

            _project_PictureService = project_PictureService;

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

            model.Project_PictureModels = _project_PictureService.GetAll().Where(x => x.Sorting == "1").ToList();

            return View(model);
        }

        public ActionResult Mail()
        {
            var model = _aboutUsPageService.GetById(1);

            return Content(model.Mail);
        }

    }
}