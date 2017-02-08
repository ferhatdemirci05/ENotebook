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
    public class HomeController : Controller
    {
        NotebookBLL _notebookBLL = new NotebookBLL();
        // GET: Home
        public ActionResult Index()
        {
            List<Notebook> listNotebook = _notebookBLL.GetAll((int)Session["UserId"]);
            return View(listNotebook);
        }
        public ActionResult EditNotebook(int id = 0)
        {
            Notebook notebook;
            if (id != 0)
            {
                notebook = _notebookBLL.Get(id);
                if (notebook == null || notebook.User.ID != (int)Session["UserId"])
                {
                    return RedirectToAction("Index");
                }
            }
            else
                notebook = new Notebook();
            return View(notebook);
        }
        [HttpPost]
        public ActionResult EditNotebook(Notebook notebook)
        {
            if (notebook.ID == 0)
            {
                notebook.UserID = (int)Session["UserId"];
                if (_notebookBLL.Add(notebook))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Kayıt gerçekleştirilemedi";
                    return View(notebook);
                }
            }
            else
            {
                Notebook updateNotebook = _notebookBLL.Get(notebook.ID);
                updateNotebook.Name = notebook.Name;
                if (_notebookBLL.Update(updateNotebook))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Kayıt gerçekleştirilemedi";
                    return View(notebook);
                }
            }
        }
        public ActionResult DeleteNotebook(int id = 0)
        {
            if (id != 0)
            {
                Notebook notebook = _notebookBLL.Get(id);
                int userID = (int)Session["UserId"];
                ViewBag.NotebookList = _notebookBLL.GetAll(userID);
                if (notebook.User.ID == (int)Session["UserId"])
                {
                    return View(notebook);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Notebook notebook = _notebookBLL.Get(id);
            if (notebook != null)
            {

                _notebookBLL.Remove(notebook);

            }
            return RedirectToAction("Index");
        }

        public ActionResult MoveAndDelete(int deleteID, int MoveID)
        {
            _notebookBLL.MoveAndDelete(deleteID, MoveID);
            return RedirectToAction("Index");
        }
    }
}