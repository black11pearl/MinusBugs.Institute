using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MinusBugs.Institute.Web.FrontEnd.Models;

namespace MinusBugs.Institute.Web.FrontEnd.Controllers
{
    public class Student2Controller : Controller
    {
        private MinusBugsContext db = new MinusBugsContext();

        // GET: /Student2/
        public ActionResult Index()
        {
            return View(db.StudentsData.ToList());
        }

        // GET: /Student2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.StudentsData.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Admno,FirstName,LastName,Dob,Gender,MobileNumber,Email,GuardianNumber,Adress,City,State,Pincode,College,Qualification,YearofPassing,Technology,CourseType,Regsitered,DateofRegistration,DateofJoining,DateofCompletion,ReferredBy,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.StudentsData.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.StudentsData.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Admno,FirstName,LastName,Dob,Gender,MobileNumber,Email,GuardianNumber,Adress,City,State,Pincode,College,Qualification,YearofPassing,Technology,CourseType,Regsitered,DateofRegistration,DateofJoining,DateofCompletion,ReferredBy,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.StudentsData.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.StudentsData.Find(id);
            db.StudentsData.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
