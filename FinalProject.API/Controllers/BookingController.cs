using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : GenericController<ExamBooking2>
    {
        private readonly IBookingService _bookingService;
        public BookingController(IGenericService<ExamBooking2> genericService, IBookingService bookingService) : base(genericService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("SearchByDate/{dateFrom}/{dateTo}")]
        public List<ExamBooking2> SearchBetweenTwoDate(DateTime? dateFrom, DateTime? dateTo)
        {
            return _bookingService.SearchBetweenTwoDate(dateFrom, dateTo);
        }

        [HttpGet]
        [Route("GetAllAvailableTimeForEachExam/{id}")]
        public List<DateTime?> GetAllAvailableTimeForEachExam(int id)
        {
            return _bookingService.GetAllAvailableTimeForEachExam(id);
        }

        [HttpGet]
        [Route("GetMyBooking/{userId}")]
        public List<MyBooking> GetMyBooking(int userId)
        {
            return _bookingService.GetMyBooking(userId);
        }
    }
}
