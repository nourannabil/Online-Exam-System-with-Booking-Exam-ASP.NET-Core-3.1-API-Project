using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IBookingCycleRepository 
    {
         int BookingCycle(BookingCycle bookingCycle);
       
    }
}
