using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class UserTable2
    {
        public UserTable2()
        {
            ExamBooking2s = new HashSet<ExamBooking2>();
            ExamCertificate2s = new HashSet<ExamCertificate2>();
            LoginTable2s = new HashSet<LoginTable2>();
            TestimonialTable2s = new HashSet<TestimonialTable2>();
        }

        public decimal Userid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Imagepath { get; set; }

        public virtual ICollection<ExamBooking2> ExamBooking2s { get; set; }
        public virtual ICollection<ExamCertificate2> ExamCertificate2s { get; set; }
        public virtual ICollection<LoginTable2> LoginTable2s { get; set; }
        public virtual ICollection<TestimonialTable2> TestimonialTable2s { get; set; }
    }
}
