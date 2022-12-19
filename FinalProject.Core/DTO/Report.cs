using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class Report
    {
        public string CourseName { get; set; }
        public string ExamName { get; set; }
        public int NUMOFUSER { get; set; }
        public int NUMOFEXAMS { get; set; }
        public int NUMOFBOOKING { get; set; }
        public int NUMOFEXAMBOOKED { get; set; }
        public int EXAMNOTBOOKED { get; set; }
        public int NUMOFUSERBOOKED { get; set; }
        public DateTime? Examdateuser { get; set; }

    }
}
