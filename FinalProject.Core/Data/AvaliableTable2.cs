using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class AvaliableTable2
    {
        public decimal Avaliableid { get; set; }
        public DateTime? Examstartdate { get; set; }
        public decimal? Examid { get; set; }
        public decimal? Statusid { get; set; }

        public virtual Exam2 Exam { get; set; }
        public virtual StatusTable2 Status { get; set; }
    }
}
