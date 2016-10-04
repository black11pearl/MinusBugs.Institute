using MinusBugs.Institute.Web.FrontEnd.Models;
using MinusBugs.Institute.Web.FrontEnd.Models.dbOperations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Inspinia_MVC5.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {

        private MinusBugsContext db = new MinusBugsContext();

        // GET: Courses
        public ActionResult Index()
        {
            CourseOperations cop = new CourseOperations();
            ViewBag.Courses = cop.GetCourses();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Courses course)
        {
            CourseOperations co = new CourseOperations();
            co.NewCourse(course);
            // return View();
            return RedirectToAction("Index");
        }

        //public ActionResult Edit(int id)
        //{
        //    CourseOperations cop = new CourseOperations();
        //    Courses course = cop.GetCourse(id);
        //    //return View(course);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult GetCourseJson(int id)
        {
            CourseOperations cop = new CourseOperations();
           
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(cop.GetCourse(id));
            return Json(strJSON);
        }

        public ActionResult LoadGraph()
        {

            CourseGraphOperations cgo = new CourseGraphOperations();
            List<CourseGraph> cglist = cgo.GetGraph();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(cglist);
            return Json(strJSON);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.CourseData.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // GET: /Courses1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.CourseData.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: /Courses1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseTitle,Description,CourseType,Duration_in_Hrs,CourseFee")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }


        // GET: /Courses1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.CourseData.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: /Courses1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.CourseData.Find(id);
            db.CourseData.Remove(courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}