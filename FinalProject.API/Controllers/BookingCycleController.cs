using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCycleController : ControllerBase
    {

        private readonly IBookingCycleService _bookingCycleService;
        public BookingCycleController(IBookingCycleService bookingCycleService)
        {
            _bookingCycleService = bookingCycleService;
        }

        [HttpPost]
        [Route("BookExam")]
        public void BookingCycle(BookingCycle bookingCycle)
        {
            _bookingCycleService.BookingCycle(bookingCycle);

        }
    }
}




