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
    [Authorize]
    public class tblInstsController : Controller
    {
        private MinusBugsContext db = new MinusBugsContext();

        // GET: /tblInsts/
        public ActionResult Index()
        {
            return View(db.tblInstData.ToList());
        }

        // GET: /tblInsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInst tblInst = db.tblInstData.Find(id);
            if (tblInst == null)
            {
                return HttpNotFound();
            }
            return View(tblInst);
        }

        // GET: /tblInsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /tblInsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="InstituteId,InstituteName,ContactPerson,Email,Phone,Address,Discontinued")] tblInst tblInst)
        {
            if (ModelState.IsValid)
            {
                db.tblInstData.Add(tblInst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblInst);
        }

        // GET: /tblInsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInst tblInst = db.tblInstData.Find(id);
            if (tblInst == null)
            {
                return HttpNotFound();
            }
            return View(tblInst);
        }

        // POST: /tblInsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InstituteId,InstituteName,ContactPerson,Email,Phone,Address,Discontinued")] tblInst tblInst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblInst);
        }

        // GET: /tblInsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInst tblInst = db.tblInstData.Find(id);
            if (tblInst == null)
            {
                return HttpNotFound();
            }
            return View(tblInst);
        }

        // POST: /tblInsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInst tblInst = db.tblInstData.Find(id);
            db.tblInstData.Remove(tblInst);
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
