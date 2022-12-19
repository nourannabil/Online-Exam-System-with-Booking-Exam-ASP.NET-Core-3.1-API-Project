using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class ContactUsForm2
    {
        public decimal Contactformid { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public decimal? Homeid { get; set; }

        public virtual HomeTable2 Home { get; set; }
    }
}
