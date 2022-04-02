using DBSD_CW.DAL;
using DBSD_CW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSD_CW.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            var repository = new StaffRepository();
            var staff = repository.GetAll();
            return View(staff);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            var repository = new StaffRepository();
            try
            {
                repository.Insert(staff);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Edit/5
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

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Delete/5
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
