using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IOurServiceService _ourServiceService;

        private readonly IProjectCategoryService _projectCategoryService;

        private readonly IProjectService _projectService;

        private readonly INewsService _newsService;

        public NewsController(ISiteConstantService siteConstantService, IOurServiceService ourServiceService, IProjectCategoryService projectCategoryService, IProjectService projectService, INewsService newsService)
        {
            _siteConstantService = siteConstantService;

            _ourServiceService = ourServiceService;

            _projectCategoryService = projectCategoryService;

            _projectService = projectService;

            _newsService = newsService;
        }

        // GET: News
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.Newses = _newsService.GetAll().ToPagedList(1,8);

            return View(model);
        }

        public ActionResult Pager(int page)
        {
            ViewModel model = new ViewModel();

            model.Newses = _newsService.GetAll().ToPagedList(page, 8);

            return PartialView("_News", model);
        }

        public ActionResult Detail(int id)
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.newsModels = _newsService.GetAll().ToList();

            model.NewsModel = _newsService.GetById(id);

            return View(model);
        }
    }
}