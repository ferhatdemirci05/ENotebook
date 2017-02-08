using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(NotebookContext context) : base(context)
        {
        }
    }
}
