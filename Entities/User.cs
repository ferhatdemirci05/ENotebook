using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
            Notebooks = new HashSet<Notebook>();
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderID { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Notebook> Notebooks { get; set; }
    }
}
