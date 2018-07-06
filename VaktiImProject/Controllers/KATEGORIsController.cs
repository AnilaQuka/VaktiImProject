using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{
    public class KATEGORIsController : Controller
    {
        private Vakti_ImEntities db = new Vakti_ImEntities();

        // GET: KATEGORIs
        public ActionResult Index()
        {
            return View(db.KATEGORIs.ToList());
        }

        // GET: KATEGORIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORI kATEGORI = db.KATEGORIs.Find(id);
            if (kATEGORI == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORI);
        }

        // GET: KATEGORIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KATEGORIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategori_id,emri")] KATEGORI kATEGORI)
        {
            if (ModelState.IsValid)
            {
                db.KATEGORIs.Add(kATEGORI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kATEGORI);
        }

        // GET: KATEGORIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORI kATEGORI = db.KATEGORIs.Find(id);
            if (kATEGORI == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORI);
        }

        // POST: KATEGORIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategori_id,emri")] KATEGORI kATEGORI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kATEGORI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kATEGORI);
        }

        // GET: KATEGORIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KATEGORI kATEGORI = db.KATEGORIs.Find(id);
            if (kATEGORI == null)
            {
                return HttpNotFound();
            }
            return View(kATEGORI);
        }

        // POST: KATEGORIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KATEGORI kATEGORI = db.KATEGORIs.Find(id);
            db.KATEGORIs.Remove(kATEGORI);
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
