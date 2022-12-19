using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class UserInvoice
    {  
        // from invoice table
        public decimal Id { get; set; }
        public decimal? BalanceAfterPay { get; set; } //its newbalance in visa (balance after pay)
        public DateTime? Paydate { get; set; } 
        
        // from exam table
        public decimal Examprice { get; set; }
        public string Name { get; set; }

        // from visa table
        public string Cardnumber { get; set; } //visa paid from

        // from Booiking table
        public decimal Bookingid { get; set; }
        public DateTime? Examdateuser { get; set; }
    }
}
