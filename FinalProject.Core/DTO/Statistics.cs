using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class Statistics
    {
        public int NumOfBooking { get; set; } //number of all booking in website
        public int NumOfUser { get; set; } //number of all user registerd in website
        public int NumOfExams { get; set; } //number of all exams in website
        public int NumOfExamBooked { get; set; } 
        public int NumOfUserBooked { get; set; } // number of users has been booked 
        public int ExamNotBooked { get; set; } 
    }
}
