using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class OurServiceController : BaseController
    {
        private readonly IOurServiceService _ourServiceService;

        public OurServiceController(IOurServiceService ourServiceService, ICategoryService categoryService)
        {
            _ourServiceService = ourServiceService;

        }
        // GET: Panel/OurService
        public ActionResult Index()
        {
            List<OurServiceModel> models = _ourServiceService.GetAll().ToList();

            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OurServiceModel ourServiceModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(ourServiceModel.ImageFile.FileName);

            string extension = Path.GetExtension(ourServiceModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            ourServiceModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            ourServiceModel.ImageFile.SaveAs(fileName);

            _ourServiceService.Add(ourServiceModel);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            OurServiceModel model = _ourServiceService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(OurServiceModel ourServiceModel)
        {
            if (ourServiceModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ourServiceModel.ImageFile.FileName);

                string extension = Path.GetExtension(ourServiceModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                ourServiceModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                ourServiceModel.ImageFile.SaveAs(fileName);

                _ourServiceService.Update(ourServiceModel);

            }
            else
            {
                var ourService = _ourServiceService.GetAll().FirstOrDefault(x => x.Id == ourServiceModel.Id);

                ourServiceModel.Picture = ourService.Picture;

                _ourServiceService.Update(ourServiceModel);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            bool result = false;

            OurServiceModel model = _ourServiceService.GetById(id);

            if (model != null)
            {
                _ourServiceService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}