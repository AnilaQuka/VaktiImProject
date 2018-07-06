using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.BLL;
using VaktiImProject.Models;
using Microsoft.AspNet.Identity;

namespace VaktiImProject.Controllers
{
    public class POROSIsController : Controller
    {
        private Vakti_ImEntities db = new Vakti_ImEntities();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: POROSIs
        public ActionResult Index()
        {
            try
            {
                var pOROSIs = db.POROSIs.OrderByDescending(s => s.datetime_Porosi).Include(p => p.ADRESA).Include(p => p.PERDORUE).Include(p => p.PERDORUE1);
                return View(pOROSIs.ToList());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
    
        public ActionResult Porosi()
        {
            try
            {
                return View(db.Procedure1());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
    
        public ActionResult DetajePorosie(int id)
        {
            try
            {
                var ordersService = new OrdersService();
                var model = ordersService.MerrListenEPorosive(id);


                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
       
        public ActionResult ShfaqPorosi1()
        {
            try
            {
                return View(db.ShfaqPorosi1());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }

        }
        
        public ActionResult ShfaqPorosi0()
        {
            try {
                return View(db.ShfaqPorosit0());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }

        }
        // GET: POROSIs/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                POROSI pOROSI = db.POROSIs.Find(id);
                if (pOROSI == null)
                {
                    return HttpNotFound();
                }
                return View(pOROSI);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // GET: POROSIs/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga");
                ViewBag.klient_id = new SelectList(db.PERDORUES, "perdorues_id", "emri");
                ViewBag.pergjegjes_id = new SelectList(db.PERDORUES, "perdorues_id", "emri");
                return View();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: POROSIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "porosi_id,adresa_id,datetime_Porosi,status_porosie,klient_id,pergjegjes_id,data_Modifikimit")] POROSI pOROSI)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.POROSIs.Add(pOROSI);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga", pOROSI.adresa_id);
                ViewBag.klient_id = new SelectList(db.PERDORUES, "perdorues_id", "emri", pOROSI.klient_id);
                ViewBag.pergjegjes_id = new SelectList(db.PERDORUES, "perdorues_id", "emri", pOROSI.pergjegjes_id);
                return View(pOROSI);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // GET: POROSIs/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                POROSI pOROSI = db.POROSIs.Find(id);
                if (pOROSI == null)
                {
                    return HttpNotFound();
                }
                ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga", pOROSI.adresa_id);
                ViewBag.klient_id = new SelectList(db.PERDORUES, "perdorues_id", "emri", pOROSI.klient_id);
                ViewBag.pergjegjes_id = new SelectList(db.PERDORUES, "perdorues_id", "emri", pOROSI.pergjegjes_id);
                return View(pOROSI);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: POROSIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "porosi_id,adresa_id,datetime_Porosi,status_porosie,klient_id,pergjegjes_id,data_Modifikimit")] POROSI pOROSI)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pOROSI).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga", pOROSI.adresa_id);
                ViewBag.klient_id = new SelectList(db.PERDORUES, "perdorues_id", "emri", pOROSI.klient_id);
                ViewBag.pergjegjes_id = new SelectList(db.PERDORUES, "perdorues_id", "emri", pOROSI.pergjegjes_id);
                return View(pOROSI);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // GET: POROSIs/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                POROSI pOROSI = db.POROSIs.Find(id);
                if (pOROSI == null)
                {
                    return HttpNotFound();
                }
                return View(pOROSI);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: POROSIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                POROSI pOROSI = db.POROSIs.Find(id);
                db.POROSIs.Remove(pOROSI);
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

   
        public ActionResult Myorders(int id)
        {
            return View(db.Porosite_e_mia(id));

        }

   
        public ActionResult OrdersDetails(int id)
        {
            var orders = new OrdersService();
            var model = orders.MyOrderList(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}
