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
    public class ProjectCategoryController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IProjectCategoryService _projectCategoryService;

        private readonly IProjectService _projectService;

        private readonly IProject_PictureService _project_PictureService;

        public ProjectCategoryController(ISiteConstantService siteConstantService, IProjectCategoryService projectCategoryService, IProjectService projectService,IProject_PictureService project_PictureService)
        {
            _siteConstantService = siteConstantService;

            _projectCategoryService = projectCategoryService;

            _projectService = projectService;

            _project_PictureService = project_PictureService;
        }

        // GET: ProjectCategory
        public ActionResult Index(int id)
        {
            ViewModel model = new ViewModel();

            model.SiteConstantModel = _siteConstantService.GetById(6);

            model.ProjectCategoryModels = _projectCategoryService.GetAll().Where(x => x.Active == true).ToList();

            model.ProjectModels = _projectService.GetAll().Where(x => x.Active == true).ToList();

            model.Projects = _projectService.GetAll().Where(x => x.ProjectCategoryId == id).Where(x=>x.Active== true).ToPagedList(1, 8);

            model.ProjectCategoryModel = _projectCategoryService.GetById(id);

            model.Project_PictureModels = _project_PictureService.GetAll().Where(x => x.Sorting == "1").ToList();

            TempData["id"] = id;

            TempData.Keep();

            return View(model);
        }

        public ActionResult Pager(int page)
        {

            var id = Convert.ToInt32 (TempData["id"]);

            TempData.Keep();

            ViewModel model = new ViewModel();

            model.Projects = _projectService.GetAll().Where(x => x.ProjectCategoryId == id).Where(x => x.Active == true).ToPagedList(page, 8);

            return PartialView("_ProjectCategory", model);
        }


    }
}