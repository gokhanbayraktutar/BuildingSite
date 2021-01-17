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
    public class ProjectController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IOurServiceService _ourServiceService;

        private readonly IProjectCategoryService _projectCategoryService;

        private readonly IProjectService _projectService;

        public ProjectController(ISiteConstantService siteConstantService, IOurServiceService ourServiceService, IProjectCategoryService projectCategoryService, IProjectService projectService)
        {
            _siteConstantService = siteConstantService;

            _ourServiceService = ourServiceService;

            _projectCategoryService = projectCategoryService;

            _projectService = projectService;
        }


        // GET: Project
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.Projects = _projectService.GetAll().Where(x => x.Active == true).ToPagedList(1, 8);

            return View(model);
        }

        public ActionResult Pager(int page)
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.Projects = _projectService.GetAll().Where(x => x.Active == true).ToPagedList(page, 8);

            return PartialView("_Project",model);
        }

        public ActionResult Detail(int id)
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ourServiceModels = _ourServiceService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModel = _projectService.GetById(id);

            return View(model);
        }


    }
}