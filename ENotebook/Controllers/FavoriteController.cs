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
    public class FavoriteController : Controller
    {
        NoteBLL _noteBLL = new NoteBLL();
        // GET: Favorite
        public ActionResult Index()
        {
            int id = (int)Session["UserId"];
            List<Note> listNote = _noteBLL.GetAll(id);
            return View(listNote);
        }
    }
}