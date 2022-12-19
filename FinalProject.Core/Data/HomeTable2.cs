using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class HomeTable2
    {
        public HomeTable2()
        {
            AboutTable2s = new HashSet<AboutTable2>();
            ContactUsForm2s = new HashSet<ContactUsForm2>();
            ContactUsTable2s = new HashSet<ContactUsTable2>();
            TestimonialTable2s = new HashSet<TestimonialTable2>();
        }

        public decimal Homeid { get; set; }
        public string Imagepath { get; set; }
        public string Title { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }

        public virtual ICollection<AboutTable2> AboutTable2s { get; set; }
        public virtual ICollection<ContactUsForm2> ContactUsForm2s { get; set; }
        public virtual ICollection<ContactUsTable2> ContactUsTable2s { get; set; }
        public virtual ICollection<TestimonialTable2> TestimonialTable2s { get; set; }
    }
}
