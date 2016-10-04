using MinusBugs.Institute.Web.FrontEnd.Models;
using MinusBugs.Institute.Web.FrontEnd.Models.dbOperations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class StaffController : Controller
    {
        private MinusBugsContext db = new MinusBugsContext();
        //// GET: Staff
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff,FormCollection formcollection)
        {
            
            staff.Staff_Designation= formcollection["Designation"];
            staff.Staff_Qualification= formcollection["Qualification"];
            staff.Staff_Dob = DateTime.Now;
            staff.Staff_Date_of_Joining = DateTime.Now;


            //Create new staff
            StaffDb staffdb = new StaffDb();
            bool new_staff_create_status=staffdb.NewStaff(staff);

            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult EditStaff(int id)
        //{
        //    StaffDb sdb = new StaffDb();
        //    Staff staff = sdb.GetStaff(id);
        //    return View(staff);

        //}

        public ActionResult Search()
        {

            return View(db.StaffData);
        }

        [HttpPost]
        public ActionResult Search(string searchterm)
        {
            //var staffs = db.Staffs.Include(s => s.tblInstitute);
            
            List<Staff> staffs;

            if (string.IsNullOrEmpty(searchterm))
            {
                staffs = db.StaffData.ToList();
                return View(staffs);
            }
            else
            {
                string strvalue = Request.Form["searchBy"].ToString();
                if (strvalue == "StaffName")
                {
                    staffs = db.StaffData.Where(x => x.StaffName.StartsWith(searchterm)).ToList();
                    return View(staffs);
                }
                else if(strvalue == "Staff_Designation")
                {
                    staffs = db.StaffData.Where(x => x.Staff_Designation.Equals(searchterm)).ToList();
                    return View(staffs);
                }
                else if (strvalue == "Staff_Technology")
                {
                    staffs = db.StaffData.Where(x => x.Staff_Technology.Equals(searchterm)).ToList();
                    return View(staffs);
                }

                return View();
            }
            

        }




        public JsonResult GetStaff(string term)
        {
            List<string> staffs;

            staffs = db.StaffData.Where(x => x.StaffName.StartsWith(term)).Select(y => y.StaffName).ToList();

            return Json(staffs, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Index()
        {
            StaffDb sdb = new StaffDb();
            List<Staff> stafflist = sdb.GetAllStaff();
            ViewBag.StaffList = stafflist;
            return View();
        }

        // GET: /Staff2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.StaffData.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: /Staff2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.StaffData.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: /Staff2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffId,Username,StaffName,Staff_Address,Staff_Email,Staff_Dob,Staff_ContactNumber,Staff_Qualification,Staff_Salary,Staff_Designation,Staff_Date_of_Joining,Staff_Status,Max_Leave_Granted_Per_Month,AboutMe")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: /Staff2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.StaffData.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: /Staff2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.StaffData.Find(id);
            db.StaffData.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}