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
    public class ReferenceController : BaseController
    {
        private readonly IReferencesService _referencesService;

        public ReferenceController(IReferencesService referencesService)
        {
            _referencesService = referencesService;
        }

        // GET: Panel/Reference
        public ActionResult Index()
        {
          List<ReferenceModel> models = _referencesService.GetAll().ToList();

          return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReferenceModel referenceModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(referenceModel.ImageFile.FileName);

            string extension = Path.GetExtension(referenceModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            referenceModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            referenceModel.ImageFile.SaveAs(fileName);

            _referencesService.Add(referenceModel);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ReferenceModel model = _referencesService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(ReferenceModel referenceModel)
        {
            if (referenceModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(referenceModel.ImageFile.FileName);

                string extension = Path.GetExtension(referenceModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                referenceModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                referenceModel.ImageFile.SaveAs(fileName);

                _referencesService.Update(referenceModel);

            }
            else
            {
                var reference = _referencesService.GetAll().FirstOrDefault(x => x.Id == referenceModel.Id);

                referenceModel.Picture = reference.Picture;

                _referencesService.Update(referenceModel);

            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            bool result = false;

            ReferenceModel model = _referencesService.GetById(id);

            if (model != null)
            {
                _referencesService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}