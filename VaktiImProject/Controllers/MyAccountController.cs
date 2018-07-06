using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{
   
    public class MyAccountController : Controller
    {
        private Vakti_ImEntities db = new Vakti_ImEntities();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        // GET: MyAccount
        [HttpGet]
        public ActionResult Login()
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Login l, string ReturnUrl = "")
        {
            

                string message = "";
                var user = db.PERDORUES.Where(a => a.username.Equals(l.Usename)).FirstOrDefault();
                if (user != null)
                {

                    if (string.Compare(Crypto.Hash(l.Password), user.password) == 0)
                    {
                        //FormsAuthentication.SetAuthCookie(user.username, l.RememberMe);
                        int timeout = l.RememberMe ? 525600 : 20;// 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(user.username, l.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            if (user.aktiv == true && user.ROLI.emri == "admin")
                            {
                                return RedirectToAction("Index", "PERDORUEs");
                            }
                            if (user.aktiv == true && user.ROLI.emri == "responsible")
                            {
                                return RedirectToAction("Index", "GATIMs");
                            }
                            if (user.aktiv == true && user.ROLI.emri == "client")
                            {
                                return RedirectToAction("ProfClient", "HOME");
                            }

                        }

                    }

                }
                else
                {
                    message = "Invalid credential provided";
                }
            
           
            ModelState.Remove("Password");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "MyAccount");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Registration()
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
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "emri,mbiemri,telefon,username,password")] PERDORUE pERDORUE)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = IsUserNameExist(pERDORUE.username);
                    if (isExist)
                    {
                        ModelState.AddModelError("", "Username qe vute ekzistonë");
                        return View(pERDORUE);
                    }
                    pERDORUE.password = Crypto.Hash(pERDORUE.password);
                    pERDORUE.krijimPerdorues = DateTime.Now;
                    pERDORUE.aktiv = true;
                    pERDORUE.rol_id = 3;
                    db.PERDORUES.Add(pERDORUE);
                    db.SaveChanges();
                    ViewBag.message = " Regjistrimi u krye me sukses!";
                    return RedirectToAction("Login", "MyAccount");
                }
              
                return View(pERDORUE);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }

        }

        [NonAction]
        public Boolean IsUserNameExist(string username)
        {
                var v = db.PERDORUES.Where(a => a.username == username).FirstOrDefault();
                return v != null;
        }
    }
}