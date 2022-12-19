using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class CourseTable2
    {
        public CourseTable2()
        {
            Exam2s = new HashSet<Exam2>();
            QuestionBank2s = new HashSet<QuestionBank2>();
        }

        public decimal Courseid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }

        public virtual ICollection<Exam2> Exam2s { get; set; }
        public virtual ICollection<QuestionBank2> QuestionBank2s { get; set; }
    }
}
