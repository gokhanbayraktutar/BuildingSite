using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{

    public class AboutUsPageController : BaseController
    {
        private readonly IAboutUsPageService _aboutUsPageService;

        public AboutUsPageController(IAboutUsPageService aboutUsPageService)
        {
            _aboutUsPageService = aboutUsPageService;
        }

        // GET: Panel/AboutUsPage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            AboutUsPageModel model = _aboutUsPageService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(AboutUsPageModel aboutUsPageModel)
        {
            if (aboutUsPageModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(aboutUsPageModel.ImageFile.FileName);

                string extension = Path.GetExtension(aboutUsPageModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                aboutUsPageModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                aboutUsPageModel.ImageFile.SaveAs(fileName);

                _aboutUsPageService.Update(aboutUsPageModel);
            }
            else
            {
                var aboutUsPage = _aboutUsPageService.GetAll().FirstOrDefault(x => x.Id == aboutUsPageModel.Id);

                aboutUsPageModel.Picture = aboutUsPage.Picture;

                _aboutUsPageService.Update(aboutUsPageModel);

            }
            return RedirectToAction("Edit");
        }

    }
}