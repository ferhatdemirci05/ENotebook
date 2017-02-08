using Bussiness;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENotebook.Controllers
{
    public class SginUpController : Controller
    {
        UserBLL _userBLL = new UserBLL();
        // GET: SginUp
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(User user,string MailConfirm,string PasswordConfirm)
        {
            string message;
            if (_userBLL.Add(user,MailConfirm,PasswordConfirm,out message))
            {
                TempData["Message"] = message;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["ErrorMessage"] = message;
                return View(user);
            }
        }
    }
}