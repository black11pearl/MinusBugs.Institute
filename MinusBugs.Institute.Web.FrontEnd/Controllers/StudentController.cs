using MinusBugs.Institute.Web.FrontEnd.Models;
using MinusBugs.Institute.Web.FrontEnd.Models.dbOperations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MinusBugs.Institute.Web.FrontEnd.Controllers
{
    public class StudentController : Controller
    {
        private MinusBugsContext db = new MinusBugsContext();
        //// GET: Student
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Student student)
        //{

        //    //student.Dob = DateTime.Now;
        //    //student.DateofEnquiry = DateTime.Now;


        //    //Add New Student
        //    StudentOperations stdoperation = new StudentOperations();
        //    TempData["student"]=  stdoperation.NewStudent(student);
        //    return RedirectToAction("Index");

        //}



        //// GET: /Student2/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /Student2/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Admno,FirstName,LastName,Dob,Gender,MobileNumber,Email,GuardianNumber,Adress,City,State,Pincode,College,Qualification,YearofPassing,Technology,CourseType,DateofEnquiry,DateofJoining,DateofCompletion,ReferredBy,Status")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentsData.Add(student);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);
        //}


        public ActionResult Index()
        {
            StudentOperations std_operations = new StudentOperations();
            ViewBag.Students = std_operations.GetAllStudents();
            return View();
        }

        public ActionResult JoinACourse()
        {

            CourseOperations co = new CourseOperations();
            ViewBag.Courses = new SelectList(co.GetCourses(), "CourseId", "CourseTitle");
            return View();

        }

        public ActionResult JoinfromList(int id)
        {
            StudentOperations sos = new StudentOperations();
            Student student = sos.GetStudent(id);
            TempData["student"] = student;
            return RedirectToAction("JoinACourse", "Student");

        }

        //// GET: /Student2/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.StudentsData.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// GET: /Student2/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.StudentsData.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: /Student2/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Admno,FirstName,LastName,Dob,MobileNumber,Email,GuardianNumber,Adress,City,State,Pincode,DateofRegistration")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(student).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(student);
        //}

        //// GET: /Student2/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.StudentsData.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: /Student2/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student student = db.StudentsData.Find(id);
        //    db.StudentsData.Remove(student);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
        public ActionResult Create([Bind(Include = "Admno,FirstName,LastName,Dob,Gender,MobileNumber,Email,GuardianNumber,Adress,City,State,Pincode,College,Qualification,YearofPassing,Technology,CourseType,Regsitered,DateofRegistration,DateofJoining,DateofCompletion,ReferredBy,Status")] Student student)
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
        public ActionResult Edit([Bind(Include = "Admno,FirstName,LastName,Dob,Gender,MobileNumber,Email,GuardianNumber,Adress,City,State,Pincode,College,Qualification,YearofPassing,Technology,CourseType,Regsitered,DateofRegistration,DateofJoining,DateofCompletion,ReferredBy,Status")] Student student)
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


        public ActionResult Search()
        {

            return View(db.StudentsData);
        }

        [HttpPost]
        public ActionResult Search(string searchterm)
        {
            //var staffs = db.Staffs.Include(s => s.tblInstitute);

            List<Student> students;

            if (string.IsNullOrEmpty(searchterm))
            {
                students = db.StudentsData.ToList();
                return View(students);
            }
            else
            {
                string strvalue = Request.Form["searchBy"].ToString();
                if (strvalue == "FirstName")
                {
                    students = db.StudentsData.Where(x => x.FirstName.StartsWith(searchterm)).ToList();
                    return View(students);
                }
                else if (strvalue == "CourseType")
                {
                    students = db.StudentsData.Where(x => x.CourseType.Equals(searchterm)).ToList();
                    return View(students);
                }
                else if (strvalue == "Technology")
                {
                    students = db.StudentsData.Where(x => x.Technology.Equals(searchterm)).ToList();
                    return View(students);
                }

                return View();
            }


        }




        public JsonResult GetStudent(string term)
        {
            List<string> students;

            students = db.StudentsData.Where(x => x.FirstName.StartsWith(term)).Select(y => y.FirstName).ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
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