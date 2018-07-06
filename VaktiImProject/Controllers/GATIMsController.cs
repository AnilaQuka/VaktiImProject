using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.BLL;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{


    public class GATIMsController : Controller
    {
        private Vakti_ImEntities db = new Vakti_ImEntities();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet]
        
        public ActionResult Add()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
        [HttpPost]
        public ActionResult Add(GATIM gATIM)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(gATIM.ImageFile.FileName);
                string extension = Path.GetExtension(gATIM.ImageFile.FileName);
                filename = filename + extension;
                gATIM.foto = "~/Foto/" + filename;
                filename = Path.Combine(Server.MapPath("~/Foto/") + filename);
                //gATIM.ImageFile.SaveAs(Server.MapPath("~/Foto" + filename));
                db.GATIMs.Add(gATIM);
                db.SaveChanges();

                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }

        }
        [HttpGet]
      
        public ActionResult View(int id)
        {
            try
            {
                GATIM gATIM = new GATIM();

                gATIM = db.GATIMs.Where(x => x.gatim_id == id).FirstOrDefault();


                return View(gATIM);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
  
        public ActionResult Index()
        {
            try
            {
                var gATIMs = db.GATIMs.OrderByDescending(a=>a.datakrijimit).Include(g => g.PERDORUE).Include(g => g.PERDORUE1).Include(g => g.KATEGORI);
                return View(gATIMs.ToList());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }

        }
        // GET: GATIMs/Details/5
        [HttpGet]
        
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                GATIM gATIM = db.GATIMs.Where(x => x.gatim_id == id).FirstOrDefault();
                gATIM = db.GATIMs.Find(id);
                GATIM gt = new GATIM { foto = "data:Foto" };

                gt.gatim = gATIM;

                if (gATIM == null)
                {
                    return HttpNotFound();
                }
                return View(gATIM);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
        // GET: GATIMs/Edit/5
    
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                GATIM gATIM = db.GATIMs.Find(id);
                if (gATIM == null)
                {
                    return HttpNotFound();
                }
                ViewBag.createdBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.createdBy);
                ViewBag.modifiedBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.modifiedBy);
                ViewBag.kategori_id = new SelectList(db.KATEGORIs, "kategori_id", "emri", gATIM.kategori_id);
                return View(gATIM);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: GATIMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gatim_id,emriGatimit,pershkrimi,cmimi,disponueshmeria,foto,datakrijimit,datamodifikimit,createdBy,modifiedBy,kategori_id")] GATIM gATIM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(gATIM).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.createdBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.createdBy);
                ViewBag.modifiedBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.modifiedBy);
                ViewBag.kategori_id = new SelectList(db.KATEGORIs, "kategori_id", "emri", gATIM.kategori_id);
                return View(gATIM);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // GET: GATIMs/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                GATIM gATIM = db.GATIMs.Find(id);
                if (gATIM == null)
                {
                    return HttpNotFound();
                }
                return View(gATIM);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: GATIMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                GATIM gATIM = db.GATIMs.Find(id);
                db.GATIMs.Remove(gATIM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
               
            }
        }
  
        public ActionResult GatimetAktive()
        {
            try
            {
                var gatime = new GatimetService();
                var model = gatime.MerrListenEGatimeve();

                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
    
        public ActionResult ListoGatimet()
        {
            try
            {
                var gatime = new GatimetService();
                var model = gatime.MerrListenEGatimeve();

                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
    
        public ActionResult GatimeDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                GATIM gATIM = db.GATIMs.Find(id);
                if (gATIM == null)
                {
                    return HttpNotFound();
                }
                return View(gATIM);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

    }
}
