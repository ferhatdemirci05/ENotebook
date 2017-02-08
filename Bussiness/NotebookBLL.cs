using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class NotebookBLL : IBussiness<Notebook>
    {
        UnitOfWork _uow;
        public NotebookBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Notebook item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
            {
                item.DateOfCration = DateTime.Now;
                _uow.NotebookRepository.Add(item);
                if (_uow.ApplyChanges())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Notebook> GetAll(int id)
        {
            return _uow.NotebookRepository.GetAll().Where(x => x.User.ID == id).OrderByDescending(x => x.DateOfCration).ToList();
        }

        public Note ShareNot(int id)
        {
            Note note = _uow.NoteRepository.GetAll().FirstOrDefault(x => x.ID == id);
            if (note.Share)
            {
                note.Share = false;
            }
            else
            {
                note.Share = true;
            }
            _uow.NoteRepository.Update(note);
            _uow.ApplyChanges();
            return note;
        }

        public Note Favorite(int id)
        {
            Note note = _uow.NoteRepository.GetAll().FirstOrDefault(x => x.ID == id);
            if (note.Flag)
            {
                note.Flag = false;
            }
            else
            {
                note.Flag = true;
            }
            _uow.NoteRepository.Update(note);
            _uow.ApplyChanges();
            return note;
        }

        public bool updateNote(Note note, Note noteUpdate)
        {
            note.Name = noteUpdate.Name;
            note.Description = noteUpdate.Description;
            _uow.NoteRepository.Update(note);
            return _uow.ApplyChanges();
        }

        public void AddNote(Note note)
        {
            note.DateOfCration = DateTime.Now.Date;
            _uow.NoteRepository.Add(note);
            _uow.ApplyChanges();
        }

        public void RemoveNote(Note note)
        {
            _uow.NoteRepository.Remove(note);
            _uow.ApplyChanges();
        }

        public Note GetNote(int id, bool hitControl)
        {
            Note note = _uow.NoteRepository.Get(id);
            if (note != null && hitControl)
            {
                note.Hit++;
                _uow.NoteRepository.Update(note);
                _uow.ApplyChanges();
            }
            return note;
        }

        public void MoveAndDelete(int deleteID, int moveID)
        {
            Notebook deleteNotebook = _uow.NotebookRepository.Get(deleteID);
            Notebook moveNotebook = _uow.NotebookRepository.Get(moveID);
            
            while (deleteNotebook.Notes.Count!=0)
            {
                deleteNotebook.Notes[0].NotebookID = moveNotebook.ID;
                _uow.NoteRepository.Update(deleteNotebook.Notes[0]);

            }
            _uow.NotebookRepository.Remove(deleteNotebook);
            _uow.ApplyChanges();
        }

        public Notebook Get(int id)
        {
            Notebook notebook = _uow.NotebookRepository.Get(id);
            if (notebook != null)
            {
                notebook.Notes = notebook.Notes.OrderByDescending(x => x.Hit).ToList();
            }
            return notebook;
        }

        public List<Notebook> GetAll()
        {
            return _uow.NotebookRepository.GetAll().OrderByDescending(x => x.DateOfCration).ToList();
        }

        public bool Remove(Notebook item)
        {

            while (item.Notes.Count!=0)
            {
                _uow.NoteRepository.Remove(item.Notes[0]);

            }
            _uow.NotebookRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Notebook item)
        {
            _uow.NotebookRepository.Update(item);
            if (_uow.ApplyChanges())
            {
                return true;
            }
            return false;
        }
    }
}
