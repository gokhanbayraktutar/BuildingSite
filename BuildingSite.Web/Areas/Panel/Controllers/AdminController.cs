﻿using BuildingSite.Contracts.IRepository;
using BuildingSite.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class AdminController : BaseController
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
            List<AdminModel> model = _adminService.GetAll().ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            model.AdminModels = _adminService.GetAll().Where(x => x.Id == id).ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(AdminModel adminModel)
        {
            _adminService.Update(adminModel);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdminModel adminModel)
        {
            _adminService.Add(adminModel);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            bool result = false;

            AdminModel model = _adminService.GetById(id);

            if (model != null)
            {
                _adminService.Remove(model.Id);

                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}