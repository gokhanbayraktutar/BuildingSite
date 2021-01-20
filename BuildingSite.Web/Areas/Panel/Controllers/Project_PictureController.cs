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
    public class Project_PictureController : Controller
    {
        private readonly IProject_PictureService _project_PictureService;

        private readonly IProjectService _projectService;

        public Project_PictureController(IProject_PictureService project_PictureService, IProjectService projectService)
        {
            _project_PictureService = project_PictureService;

            _projectService = projectService;
        }

        // GET: Panel/Project_Picture
        public ActionResult Index()
        {
            var model = _project_PictureService.GetAll().ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Project_PictureModel model = new Project_PictureModel();

            model.ProjectModels = _projectService.GetAll().ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Project_PictureModel project_PictureModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(project_PictureModel.ImageFile.FileName);

            string extension = Path.GetExtension(project_PictureModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            project_PictureModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            project_PictureModel.ImageFile.SaveAs(fileName);

            _project_PictureService.Add(project_PictureModel);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Project_PictureModel model = _project_PictureService.GetById(id);

            model.ProjectModels = _projectService.GetAll().ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(Project_PictureModel project_PictureModel)
        {
            if (project_PictureModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(project_PictureModel.ImageFile.FileName);

                string extension = Path.GetExtension(project_PictureModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                project_PictureModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                project_PictureModel.ImageFile.SaveAs(fileName);

                var projectPicture = _project_PictureService.GetAll().FirstOrDefault(x => x.Id == project_PictureModel.Id);

                project_PictureModel.ProjectId = projectPicture.ProjectModel.Id;

                _project_PictureService.Update(project_PictureModel);

            }
            else
            {
                var projectPicture = _project_PictureService.GetAll().FirstOrDefault(x => x.Id == project_PictureModel.Id);

                project_PictureModel.Picture = projectPicture.Picture;

                project_PictureModel.ProjectId = projectPicture.ProjectModel.Id;

                _project_PictureService.Update(project_PictureModel);

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Project_PictureModel model = _project_PictureService.GetById(id);

            if (model != null)
            {
                _project_PictureService.Remove(model.Id);
            }

            return RedirectToAction("Index");
        }
    }
}