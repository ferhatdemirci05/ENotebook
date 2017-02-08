using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class NotebookRepository : BaseRepository<Notebook>
    {
        public NotebookRepository(NotebookContext context) : base(context)
        {
        }
    }
}
