using MinusBugs.Institute.Web.FrontEnd.Models.dbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinusBugs.Institute.Web.FrontEnd.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            //return View();
            StudentOperations std_operations = new StudentOperations();
            ViewBag.Students = std_operations.GetAllStudents();
            return View();
        }

        // GET: Batch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Batch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batch/Create
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

        // GET: Batch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Batch/Edit/5
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

        // GET: Batch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Batch/Delete/5
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
