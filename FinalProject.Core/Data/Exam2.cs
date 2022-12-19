using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class Exam2
    {
        public Exam2()
        {
            AvaliableTable2s = new HashSet<AvaliableTable2>();
            ExamBooking2s = new HashSet<ExamBooking2>();
        }

        public decimal Examid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }
        public decimal? Examduration { get; set; }
        public decimal Examprice { get; set; }
        public decimal? Passmark { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? NUMOFQUESTIONS { get; set; }
        public virtual CourseTable2 Course { get; set; }
        public virtual ICollection<AvaliableTable2> AvaliableTable2s { get; set; }
        public virtual ICollection<ExamBooking2> ExamBooking2s { get; set; }
    }
}
