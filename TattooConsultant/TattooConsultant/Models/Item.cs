using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TattooConsultant.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Up { get; set; }
        public string Down { get; set; }
        public string Photo { get; set; }
        public string Description { get; set;}
        public string Sex { get; set; }

    }
}