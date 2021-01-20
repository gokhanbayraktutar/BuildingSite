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

        private readonly IProjectCategoryService _projectCategoryService;

        private readonly IProjectService _projectService;

        private readonly IProject_PictureService _project_PictureService;

        public ProjectController(ISiteConstantService siteConstantService, IProjectCategoryService projectCategoryService, IProjectService projectService, IProject_PictureService project_PictureService)
        {
            _siteConstantService = siteConstantService;

            _projectCategoryService = projectCategoryService;

            _projectService = projectService;

            _project_PictureService = project_PictureService;
        }


        // GET: Project
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.Projects = _projectService.GetAll().Where(x => x.Active == true).ToPagedList(1, 8);

            model.Project_PictureModels = _project_PictureService.GetAll().Where(x => x.Sorting=="1").ToList();

            return View(model);
        }

        public ActionResult Pager(int page)
        {
            ViewModel model = new ViewModel();

            model.Projects = _projectService.GetAll().Where(x => x.Active == true).ToPagedList(page, 8);

            return PartialView("_Project",model);
        }

        public ActionResult Detail(int id)
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModel = _projectService.GetById(id);

            model.project_PictureModel = _project_PictureService.GetAll().FirstOrDefault(x => x.ProjectId == id);

            model.Project_PictureModels = _project_PictureService.GetAll().Where(x => x.ProjectId == id).ToList();

            return View(model);
        }


    }
}