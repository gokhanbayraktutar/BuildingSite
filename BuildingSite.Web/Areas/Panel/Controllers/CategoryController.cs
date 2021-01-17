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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Panel/Category
        public ActionResult Index()
        {
            List<CategoryModel> models = _categoryService.GetAll().ToList();

            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(categoryModel.ImageFile.FileName);

            string extension = Path.GetExtension(categoryModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            categoryModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            categoryModel.ImageFile.SaveAs(fileName);

            _categoryService.Add(categoryModel);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CategoryModel model = _categoryService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(CategoryModel categoryModel)
        {
            if (categoryModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(categoryModel.ImageFile.FileName);

                string extension = Path.GetExtension(categoryModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                categoryModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                categoryModel.ImageFile.SaveAs(fileName);

                _categoryService.Update(categoryModel);

            }
            else
            {
                var category = _categoryService.GetAll().FirstOrDefault(x => x.Id == categoryModel.Id);

                categoryModel.Picture = category.Picture;

                _categoryService.Update(categoryModel);

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            bool result = false;

            CategoryModel model = _categoryService.GetById(id);

            if (model != null)
            {
                _categoryService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}