using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class MyCertificate
    {
        public decimal Certificateid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Bookingid { get; set; }

        //From ExamBooking2
        public DateTime? Examdateuser { get; set; }

        //From Exam2
        public string ExamName { get; set; }

        //From CourseTable2
        public string CourseName { get; set; }

        //From UserTable2
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }

    }
}
