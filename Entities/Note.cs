using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Note
    {
        public int ID { get; set; }
        public int NotebookID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCration { get; set; }

        public int Hit { get; set; }
        public bool Flag { get; set; }
        public bool Share { get; set; }

        public virtual Notebook Notebook { get; set; }
    }
}
