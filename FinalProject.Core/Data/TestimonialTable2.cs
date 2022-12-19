using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class TestimonialTable2
    {
        public decimal Testimonialid { get; set; }
        public string Feedback { get; set; }
        public decimal? Statusid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Homeid { get; set; }

        public virtual HomeTable2 Home { get; set; }
        public virtual StatusTable2 Status { get; set; }
        public virtual UserTable2 User { get; set; }
    }
}
