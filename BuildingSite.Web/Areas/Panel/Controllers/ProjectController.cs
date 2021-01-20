using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;
        private readonly IProjectCategoryService _projectCategoryService;

        public ProjectController(IProjectService projectService, IProjectCategoryService projectCategoryService)
        {
            _projectService = projectService;

            _projectCategoryService = projectCategoryService;
        }

        // GET: Panel/Project
        public ActionResult Index()
        {
            List<ProjectModel> models = _projectService.GetAll().ToList();

            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProjectModel projectModel = new ProjectModel();

            projectModel.ProjectCategoryModels = _projectCategoryService.GetAll().ToList();

            return View(projectModel);
        }

        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            _projectService.Add(projectModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            ProjectModel model = _projectService.GetById(id);

            model.ProjectCategoryModels = _projectCategoryService.GetAll().ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(ProjectModel projectModel)
        {
            _projectService.Update(projectModel);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            bool result = false;

            ProjectModel model = _projectService.GetById(id);

            if (model != null)
            {
                _projectService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}