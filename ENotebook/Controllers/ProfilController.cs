using Bussiness;
using ENotebook.Helper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENotebook.Controllers
{
    [LoginRequired]
    public class ProfilController : Controller
    {
        UserBLL _userBLL = new UserBLL();
        // GET: Profil
        public ActionResult Index()
        {
            User user = _userBLL.Get((int)Session["UserId"]);
            return View(user);
        }

        public ActionResult PasswordUpdate( string OldPassword, string NewPassword,string NewPasswordConfirm)
        {
            string message;
            if (_userBLL.UpdatePassword((int)Session["UserId"],OldPassword,NewPassword,NewPasswordConfirm,out message))
            {
                TempData["Message"] = message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = message;
                return RedirectToAction("Index");
            }
        }
    }
}