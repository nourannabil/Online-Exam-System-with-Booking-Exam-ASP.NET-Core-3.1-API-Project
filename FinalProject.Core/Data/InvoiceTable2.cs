using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class InvoiceTable2
    {
        public decimal Id { get; set; }
        public decimal? Totalprice { get; set; }
        public DateTime? Paydate { get; set; }
        public decimal? Visaid { get; set; }
        public decimal? Bookingid { get; set; }

        public virtual ExamBooking2 Booking { get; set; }
        public virtual VisaTable2 Visa { get; set; }
    }
}
