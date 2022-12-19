using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class ContactUsTable2
    {
        public decimal Contacttableid { get; set; }
        public string Imagepath { get; set; }
        public string Title { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Map { get; set; }
        public decimal? Homeid { get; set; }

        public virtual HomeTable2 Home { get; set; }
    }
}
