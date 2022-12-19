using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class AboutTable2
    {
        public decimal Aboutid { get; set; }
        public string Imagepath { get; set; }
        public string Title { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public decimal? Homeid { get; set; }

        public virtual HomeTable2 Home { get; set; }
    }
}
