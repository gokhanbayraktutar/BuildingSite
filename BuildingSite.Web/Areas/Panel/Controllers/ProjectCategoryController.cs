using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class ProjectCategoryController : Controller
    {
        private readonly IProjectCategoryService _projectCategoryService;

        public ProjectCategoryController(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }

        // GET: Panel/ProjectCategory
        public ActionResult Index()
        {
            List<ProjectCategoryModel>  models  =_projectCategoryService.GetAll().ToList();

            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectCategoryModel projectCategoryModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(projectCategoryModel.ImageFile.FileName);

            string extension = Path.GetExtension(projectCategoryModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            projectCategoryModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            projectCategoryModel.ImageFile.SaveAs(fileName);

            _projectCategoryService.Add(projectCategoryModel);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProjectCategoryModel model = _projectCategoryService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(ProjectCategoryModel projectCategoryModel)
        {
            if (projectCategoryModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(projectCategoryModel.ImageFile.FileName);

                string extension = Path.GetExtension(projectCategoryModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                projectCategoryModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                projectCategoryModel.ImageFile.SaveAs(fileName);

                _projectCategoryService.Update(projectCategoryModel);

            }
            else
            {
                var projectCategory = _projectCategoryService.GetAll().FirstOrDefault(x => x.Id == projectCategoryModel.Id);

                projectCategoryModel.Picture = projectCategory.Picture;

                _projectCategoryService.Update(projectCategoryModel);

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            bool result = false;

            ProjectCategoryModel model = _projectCategoryService.GetById(id);

            if (model != null)
            {
                _projectCategoryService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}