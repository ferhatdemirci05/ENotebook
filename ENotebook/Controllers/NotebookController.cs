using Bussiness;
using ENotebook.Helper;
using ENotebook.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENotebook.Controllers
{
    [LoginRequired]
    public class NotebookController : Controller
    {
        NotebookBLL _notebookBLL = new NotebookBLL();
        public ActionResult Index(int id = 0)
        {
            Notebook notebook = new Notebook();
            if (id != 0)
            {
                notebook = _notebookBLL.Get(id);
                if (notebook == null || notebook.User.ID != (int)Session["UserId"])
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(notebook);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditNote(int notebookID = 0, int noteID = 0)
        {
            Note note = new Note();
            note.Notebook = _notebookBLL.Get(notebookID);
            if (notebookID != 0 && (note.Notebook != null ? (int)Session["UserId"] == note.Notebook.User.ID : false))
            {
                if (noteID == 0)
                    return View(note);
                else
                {
                    note = _notebookBLL.GetNote(noteID, false);
                    if (note != null ? note.Notebook.User.ID == (int)Session["UserId"] : false)
                        return View(note);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult EditNote(Note note, int notebookID, int noteID=0)
        {
            if (noteID!=0)
            {
                Note noteUpdate = _notebookBLL.GetNote(noteID, false);
                _notebookBLL.updateNote(noteUpdate, note);
            }
            else
            {
                note.NotebookID = notebookID;
                _notebookBLL.AddNote(note);
            }
            return Redirect("/Notebook/Index/"+notebookID);
        }
        public ActionResult deletNote(int id)
        {
            Note note = _notebookBLL.GetNote(id, false);
            _notebookBLL.RemoveNote(note);
            return Redirect("/Notebook/Index/" + note.NotebookID);
        }
        public JsonResult Share(int id)
        {
            Note note = _notebookBLL.ShareNot(id);
            ModelNote model = new ModelNote() { ID = note.ID, Name = note.Name, Description = note.Description, Share = note.Share };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Favorite(int id)
        {
            Note note = _notebookBLL.Favorite(id);
            ModelNote model = new ModelNote() { ID = note.ID, Name = note.Name, Description = note.Description, Flag = note.Flag };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNote(int id)
        {
            Note note = _notebookBLL.GetNote(id, true);
            ModelNote model = new ModelNote() { ID = note.ID, Name = note.Name, Description = note.Description, DateOfCration = note.DateOfCration.ToShortDateString(), Hit = note.Hit };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}