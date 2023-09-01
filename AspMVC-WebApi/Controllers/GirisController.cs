using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMVC_WebApi.Models;
using Newtonsoft.Json;
using System.Web.Security;


namespace AspMVC_WebApi.Controllers
{
    [AllowAnonymous]
    public class GirisController : Controller
    {
        // GET: Giris
        
        public ActionResult Giris()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(giris data) {
            int roleId = 2;
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(data.username, true);
                Session["Login"] = "admi";
                Session["roleId"] = roleId.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Cikis() {
            FormsAuthentication.SignOut();

            Session.Clear();

            return RedirectToAction("Giris", "Giris");
        }
    }
}