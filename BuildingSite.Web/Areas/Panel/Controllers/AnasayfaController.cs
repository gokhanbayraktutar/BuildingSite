using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class AnasayfaController : BaseController
    {
        // GET: Panel/Anasayfa
        public ActionResult Index()
        {
            return View();
        }
    }
}