using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_careUmore.Models;

namespace FIT5032_careUmore.Controllers
{
    public class DotorsController : Controller
    {
        private Doctors db = new Doctors();

        // GET: Dotors
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Dotors.ToList());
        }

        [Authorize]
        public ActionResult Pindex()
        {
            return View(db.Dotors.ToList());
        }

        

        // GET: Dotors/Details/5
        [Authorize]
        public ActionResult Pdetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dotor dotor = db.Dotors.Find(id);
            if (dotor == null)
            {
                return HttpNotFound();
            }
            return View(dotor);
        }

        // GET: Dotors/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dotor dotor = db.Dotors.Find(id);
            if (dotor == null)
            {
                return HttpNotFound();
            }
            return View(dotor);
        }

        // GET: Dotors/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewPage1()
        {
            return View(db.Dotors.ToList());
        }

        // POST: Dotors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,WorkYears,Locations,Email,Position,AvailabilityDate")] Dotor dotor)
        {
            if (ModelState.IsValid)
            {
                db.Dotors.Add(dotor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dotor);
        }

        // GET: Dotors/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dotor dotor = db.Dotors.Find(id);
            if (dotor == null)
            {
                return HttpNotFound();
            }
            return View(dotor);
        }

        // POST: Dotors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,WorkYears,Locations,Email,Position,AvailabilityDate")] Dotor dotor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dotor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dotor);
        }

        // GET: Dotors/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dotor dotor = db.Dotors.Find(id);
            if (dotor == null)
            {
                return HttpNotFound();
            }
            return View(dotor);
        }

        // POST: Dotors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dotor dotor = db.Dotors.Find(id);
            db.Dotors.Remove(dotor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
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
