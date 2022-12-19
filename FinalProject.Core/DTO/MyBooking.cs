using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class MyBooking
    {
        // Booking Table
        public decimal Bookingid { get; set; }
        public DateTime? Examdateuser { get; set; }
        public DateTime? Bookingdate { get; set; }
        public string Exampassword { get; set; }
        public decimal? Examid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Statusid { get; set; }
        // Exam Table
        public string ExamName { get; set; }
        public decimal? Examduration { get; set; }
        public decimal? Passmark { get; set; }
        public decimal? NUMOFQUESTIONS { get; set; }

        // Course Table
        public string CourseName { get; set; }
        public decimal? CourseId { get; set; }

    }
}
