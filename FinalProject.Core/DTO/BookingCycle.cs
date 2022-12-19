using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class BookingCycle
    {
        //for visa info 
        public string Cardnumber { get; set; }
        public decimal Cvc { get; set; }
        public DateTime? Expirydate { get; set; }
     

        //for booking info 
        public DateTime? Examdateuser { get; set; }
        public DateTime? Bookingdate { get; set; }
        public string Exampassword { get; set; }
        public decimal? Examid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Statusid { get; set; }
        public int BookId { get; set; }
    }
}
