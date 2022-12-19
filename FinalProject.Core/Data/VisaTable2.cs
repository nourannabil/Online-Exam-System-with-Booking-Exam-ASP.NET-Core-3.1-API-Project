using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class VisaTable2
    {
        public VisaTable2()
        {
            InvoiceTable2s = new HashSet<InvoiceTable2>();
        }

        public decimal Visaid { get; set; }
        public string Cardnumber { get; set; }
        public decimal Cvc { get; set; }
        public DateTime? Expirydate { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<InvoiceTable2> InvoiceTable2s { get; set; }
    }
}
