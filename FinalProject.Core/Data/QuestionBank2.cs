using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class QuestionBank2
    {
        public decimal Questionid { get; set; }
        public string Questiontitle { get; set; }
        public string Correctanswer { get; set; }
        public string Answeroption1 { get; set; }
        public string Answeroption2 { get; set; }
        public string Answeroption3 { get; set; }
        public string Answeroption4 { get; set; }
        public decimal? Questionmark { get; set; }
        public decimal? Courseid { get; set; }

        public virtual CourseTable2 Course { get; set; }
    }
}
