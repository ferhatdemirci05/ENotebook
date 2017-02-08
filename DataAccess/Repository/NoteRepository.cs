using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class NoteRepository : BaseRepository<Note>
    {
        public NoteRepository(NotebookContext context) : base(context)
        {
        }
    }
}
