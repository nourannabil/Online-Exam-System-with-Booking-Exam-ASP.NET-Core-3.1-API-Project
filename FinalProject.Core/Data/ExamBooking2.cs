using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class ExamBooking2
    {
        public ExamBooking2()
        {
            ExamCertificate2s = new HashSet<ExamCertificate2>();
            InvoiceTable2s = new HashSet<InvoiceTable2>();
        }

        public decimal Bookingid { get; set; }
        public DateTime? Examdateuser { get; set; }
        public DateTime? Bookingdate { get; set; }
        public string Exampassword { get; set; }
        public decimal? Examid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Statusid { get; set; }

        public virtual Exam2 Exam { get; set; }
        public virtual StatusTable2 Status { get; set; }
        public virtual UserTable2 User { get; set; }
        public virtual ICollection<ExamCertificate2> ExamCertificate2s { get; set; }
        public virtual ICollection<InvoiceTable2> InvoiceTable2s { get; set; }
    }
}
