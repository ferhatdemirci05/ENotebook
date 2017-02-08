using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class UnitOfWork
    {
        NotebookContext _context;
        public UnitOfWork()
        {
            _context = new NotebookContext();
        }
        UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        NoteRepository _noteRespository;
        public NoteRepository NoteRepository
        {
            get
            {
                if (_noteRespository==null)
                {
                    _noteRespository = new NoteRepository(_context);
                }
                return _noteRespository;
            }
        }
        NotebookRepository _notebookRepository;
        public NotebookRepository NotebookRepository
        {
            get
            {
                if (_notebookRepository==null)
                {
                    _notebookRepository = new NotebookRepository(_context);
                }
                return _notebookRepository;
            }

        }

        DbContextTransaction _tran;
        public bool ApplyChanges()
        {
            bool isSuccess = false;
            
            _tran = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                _context.SaveChanges();
                _tran.Commit();
                isSuccess = true;
            }
            catch (Exception)
            {
                _tran.Rollback();
                isSuccess = false;
                throw;
            }
            finally
            {
                _tran.Dispose();
            }
            return isSuccess;
            
        }
    }
}
