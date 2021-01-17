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
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        // GET: Panel/Slider
        public ActionResult Index()
        {
            List<SliderModel> sliderModels = _sliderService.GetAll().ToList();

            return View(sliderModels);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SliderModel sliderModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(sliderModel.ImageFile.FileName);

            string extension = Path.GetExtension(sliderModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            sliderModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            sliderModel.ImageFile.SaveAs(fileName);

            _sliderService.Add(sliderModel);

            return RedirectToAction("/Panel/Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SliderModel model = _sliderService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(SliderModel sliderModel)
        {
            if (sliderModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(sliderModel.ImageFile.FileName);

                string extension = Path.GetExtension(sliderModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                sliderModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                sliderModel.ImageFile.SaveAs(fileName);

                _sliderService.Update(sliderModel);

                return RedirectToAction("Index");
            }
            else
            {
                var slider = _sliderService.GetAll().FirstOrDefault(x => x.Id == sliderModel.Id);

                sliderModel.Picture = slider.Picture;

                _sliderService.Update(sliderModel);

                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Delete(int id)
        {
            bool result = false;

            SliderModel model = _sliderService.GetById(id);

            if (model != null)
            {
                _sliderService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}