using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class StatusTable2
    {
        public StatusTable2()
        {
            AvaliableTable2s = new HashSet<AvaliableTable2>();
            ExamBooking2s = new HashSet<ExamBooking2>();
            TestimonialTable2s = new HashSet<TestimonialTable2>();
        }

        public decimal Statusid { get; set; }
        public string Statusname { get; set; }

        public virtual ICollection<AvaliableTable2> AvaliableTable2s { get; set; }
        public virtual ICollection<ExamBooking2> ExamBooking2s { get; set; }
        public virtual ICollection<TestimonialTable2> TestimonialTable2s { get; set; }
    }
}
