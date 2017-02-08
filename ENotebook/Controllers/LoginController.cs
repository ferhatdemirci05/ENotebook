using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENotebook.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if ((Request.Cookies["EMail"] != null && Request.Cookies["Password"] != null) || Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Index(string EMail, string Password, string rememberMe)
        {
            if (new Helper.LoginHelper().LoginUser(EMail, Password, rememberMe, System.Web.HttpContext.Current))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Mail Adresi ve şifre kombinasyonu hatalı!";
                return View();
            }
        }
   
        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["FullName"] = null;
            Response.Cookies["EMail"].Expires = DateTime.Now.AddSeconds(-10);
            Response.Cookies["Password"].Expires = DateTime.Now.AddSeconds(-10);
            return RedirectToAction("Index");
        }
    }
}