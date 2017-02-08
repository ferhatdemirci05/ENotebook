using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class NoteBLL : IBussiness<Note>
    {
        UnitOfWork _uow;
        public NoteBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Note item)
        {
            throw new NotImplementedException();
        }

        public Note Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAllShare()
        {
            return _uow.NoteRepository.GetAll().Where(x => x.Share == true).OrderByDescending(x => x.Hit).ToList();
        }

        public List<Note> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<Note> GetAll(int id)
        {
            return _uow.NoteRepository.GetAll().Where(x => x.Notebook.UserID == id && x.Flag == true).OrderByDescending(x=>x.Hit).ToList();
        }
        public bool Remove(Note item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Note item)
        {
            throw new NotImplementedException();
        }
    }
}
