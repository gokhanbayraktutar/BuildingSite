﻿using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class SiteConstantController : Controller
    {

        private readonly ISiteConstantService _siteConstantService;

        ViewModel model = new ViewModel();

        public SiteConstantController(ISiteConstantService siteconstantService)
        {
            _siteConstantService = siteconstantService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SiteConstantModel siteConstantModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(siteConstantModel.ImageFile.FileName);

            string extension = Path.GetExtension(siteConstantModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            siteConstantModel.Logo = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            siteConstantModel.ImageFile.SaveAs(fileName);

            _siteConstantService.Add(siteConstantModel);

            return RedirectToAction("/Panel/Anasayfa");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SiteConstantModel model = _siteConstantService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(SiteConstantModel siteConstantModel)
        {
            if (siteConstantModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(siteConstantModel.ImageFile.FileName);

                string extension = Path.GetExtension(siteConstantModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                siteConstantModel.Logo = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                siteConstantModel.ImageFile.SaveAs(fileName);

                if(siteConstantModel.ImageFile2 != null)
                {
                    string fileName2 = Path.GetFileNameWithoutExtension(siteConstantModel.ImageFile2.FileName);

                    string extension2 = Path.GetExtension(siteConstantModel.ImageFile2.FileName);

                    fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;

                    siteConstantModel.PictureOurService = fileName2;

                    fileName2 = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName2);

                    siteConstantModel.ImageFile2.SaveAs(fileName2);

                    _siteConstantService.Update(siteConstantModel);
                }
                else
                {
                    var siteConstant = _siteConstantService.GetAll().FirstOrDefault(x => x.Id == siteConstantModel.Id);

                    siteConstantModel.PictureOurService = siteConstant.PictureOurService;

                    _siteConstantService.Update(siteConstantModel);
                }
                
            }

            else
            {
                var siteConstant = _siteConstantService.GetAll().FirstOrDefault(x => x.Id == siteConstantModel.Id);

                siteConstantModel.Logo = siteConstant.Logo;

                if (siteConstantModel.ImageFile2 != null)
                {
                    string fileName2 = Path.GetFileNameWithoutExtension(siteConstantModel.ImageFile2.FileName);

                    string extension2 = Path.GetExtension(siteConstantModel.ImageFile2.FileName);

                    fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;

                    siteConstantModel.PictureOurService = fileName2;

                    fileName2 = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName2);

                    siteConstantModel.ImageFile2.SaveAs(fileName2);

                    _siteConstantService.Update(siteConstantModel);
                }
                else
                {

                    siteConstantModel.PictureOurService = siteConstant.PictureOurService;

                    _siteConstantService.Update(siteConstantModel);
                }
            }
            return RedirectToAction("Edit");
        }

        public ActionResult Logo()
        {
            var  model = _siteConstantService.GetById(6);

            return Content(model.Logo);
        }

        public ActionResult Header()
        {
            var  model = _siteConstantService.GetById(6);

            return Content(model.Header);
        }
    }
}