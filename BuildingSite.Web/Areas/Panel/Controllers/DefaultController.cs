using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingSite.Web.Areas.Panel.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Panel/Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: Panel/Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Panel/Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panel/Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panel/Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Panel/Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panel/Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Panel/Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
