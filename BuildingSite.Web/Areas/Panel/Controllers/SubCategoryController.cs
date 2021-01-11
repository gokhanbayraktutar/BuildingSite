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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;


        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        // GET: Panel/SubCategory
        public ActionResult Index()
        {
            List<SubCategoryModel> models = _subCategoryService.GetAll().ToList();

            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SubCategoryModel model = new SubCategoryModel();

            model.CategoryModels = _categoryService.GetAll().ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SubCategoryModel subCategoryModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(subCategoryModel.ImageFile.FileName);

            string extension = Path.GetExtension(subCategoryModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            subCategoryModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            subCategoryModel.ImageFile.SaveAs(fileName);

            _subCategoryService.Add(subCategoryModel);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SubCategoryModel model = new SubCategoryModel();

            model.CategoryModels = _categoryService.GetAll().ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(SubCategoryModel subCategoryModel)
        {
            if (subCategoryModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(subCategoryModel.ImageFile.FileName);

                string extension = Path.GetExtension(subCategoryModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                subCategoryModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                subCategoryModel.ImageFile.SaveAs(fileName);

                _subCategoryService.Update(subCategoryModel);

            }
            else
            {
                var category = _subCategoryService.GetAll().FirstOrDefault(x => x.Id == subCategoryModel.Id);

                subCategoryModel.Picture = category.Picture;

                _subCategoryService.Update(subCategoryModel);

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            bool result = false;

            SubCategoryModel model = _subCategoryService.GetById(id);

            if (model != null)
            {
                _subCategoryService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}