using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Notebook
    {
        public Notebook()
        {
            Notes = new List<Note>();
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCration { get; set; }

        public virtual User User { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}
