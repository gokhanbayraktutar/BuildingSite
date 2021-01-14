using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteConstantService _siteConstantService;

        private readonly IAboutUsPageService _aboutUsPageService;

        private readonly IOurServiceService _ourServiceService;

        private readonly ISliderService _sliderService;

        public HomeController(ISiteConstantService siteConstantService, IAboutUsPageService aboutUsPageService, IOurServiceService ourServiceService , ISliderService sliderService)
        {
            _siteConstantService = siteConstantService;

            _aboutUsPageService = aboutUsPageService;

            _ourServiceService = ourServiceService;

            _sliderService = sliderService; 
        }

        public ActionResult Index()
        {
            ViewModel model = new ViewModel();

            model.sliderModels = _sliderService.GetAll().ToList();

            return View(model);
        }

        public ActionResult Mail()
        {
            var model = _aboutUsPageService.GetById(1);

            return Content(model.Mail);
        }

        public ActionResult Header()
        {
            var model = _siteConstantService.GetById(6);

            return Content(model.Header);
        }


        public ActionResult Phone()
        {
            var model = _aboutUsPageService.GetById(1);

            return Content(model.Phone);
        }
        public ActionResult Logo()
        {
            var model = _siteConstantService.GetById(6);

            return Content(model.Logo);
        }

        public ActionResult WorkTime()
        {
            var model = _siteConstantService.GetById(6);

            return Content(model.WorkTime);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult OurService()
        //{
        //    ViewModel model = new ViewModel();

        //    model.ourServiceModels =_ourServiceService.GetAll().ToList();

        //    return Content(model);
        //}

        private ActionResult Content(ViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}