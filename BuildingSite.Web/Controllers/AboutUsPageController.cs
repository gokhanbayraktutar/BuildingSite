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

        private readonly IOurServiceService _ourServiceService;

        private readonly IProjectCategoryService _projectCategoryService;

        private readonly IProjectService _projectService;

        private readonly IAboutUsPageService _aboutUsPageService;

        public AboutUsPageController(ISiteConstantService siteConstantService, IOurServiceService ourServiceService, IProjectCategoryService projectCategoryService, IProjectService projectService, IAboutUsPageService aboutUsPageService)
        {
            _siteConstantService = siteConstantService;

            _ourServiceService = ourServiceService;

            _projectCategoryService = projectCategoryService;

            _projectService = projectService;

            _aboutUsPageService = aboutUsPageService;
        }
        // GET: AboutUsPage
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.AboutUsPageModel = _aboutUsPageService.GetById(1);

            return View(model);
        }
    }
}