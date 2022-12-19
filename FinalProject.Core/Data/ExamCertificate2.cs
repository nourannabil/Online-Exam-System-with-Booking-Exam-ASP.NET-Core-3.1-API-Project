using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class ExamCertificate2
    {
        public decimal Certificateid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Bookingid { get; set; }

        public virtual ExamBooking2 Booking { get; set; }
        public virtual UserTable2 User { get; set; }
    }
}
