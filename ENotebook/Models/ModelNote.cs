using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENotebook.Models
{
    public class ModelNote
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String DateOfCration { get; set; }

        public int Hit { get; set; }
        public bool Flag { get; set; }
        public bool Share { get; set; }
    }
}