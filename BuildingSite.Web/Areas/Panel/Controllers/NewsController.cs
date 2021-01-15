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
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: Panel/News
        public ActionResult Index()
        {
            List<NewsModel> models = _newsService.GetAll().ToList();

            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsModel newsModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(newsModel.ImageFile.FileName);

            string extension = Path.GetExtension(newsModel.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            newsModel.Picture = fileName;

            fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

            newsModel.ImageFile.SaveAs(fileName);

            newsModel.Date = DateTime.Now;

            _newsService.Add(newsModel);

            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            NewsModel model = _newsService.GetById(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(NewsModel newsModel)
        {
            if (newsModel.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(newsModel.ImageFile.FileName);

                string extension = Path.GetExtension(newsModel.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                newsModel.Picture = fileName;

                fileName = Path.Combine(Server.MapPath("~/Upload/Image/"), fileName);

                newsModel.ImageFile.SaveAs(fileName);

                newsModel.Date = DateTime.Now;

                _newsService.Update(newsModel);
            }
            else
            {
                var news = _newsService.GetAll().FirstOrDefault(x => x.Id == newsModel.Id);

                newsModel.Picture = news.Picture;

                newsModel.Date = DateTime.Now;

                _newsService.Update(newsModel);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            bool result = false;

            NewsModel model = _newsService.GetById(id);

            if (model != null)
            {
                _newsService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}