using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminService _adminService;

        ViewModel model = new ViewModel();

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        



        // GET: Panel/Admin
        public ActionResult Index()
        {
            model.AdminModels = _adminService.GetAll().ToList();

            return View(model);
        }

        public ActionResult Edit()
        {

        }

    }
}