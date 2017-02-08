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
    public class ShareController : Controller
    {
        NoteBLL _noteBLL = new NoteBLL();
        // GET: Share
        public ActionResult Index()
        {
            List<Note> listNote = _noteBLL.GetAllShare();
            return View(listNote);
        }
    }
}