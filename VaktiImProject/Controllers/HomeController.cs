using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.BLL;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{
    
    public class HomeController : Controller
    {
        private Vakti_ImEntities db = new Vakti_ImEntities();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ActionResult Index()
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

        public ActionResult About()
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

        public ActionResult Contact()
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
        [Authorize]
        public ActionResult MyProfile()
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

        public ActionResult ProfClient()
        {
            return View();
        }


    }
}