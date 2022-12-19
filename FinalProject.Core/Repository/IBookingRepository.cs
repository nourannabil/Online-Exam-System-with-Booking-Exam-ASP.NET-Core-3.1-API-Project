using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IBookingRepository
    {
        List<ExamBooking2> SearchBetweenTwoDate(DateTime? dateFrom,DateTime? dateTo);
        List<DateTime?> GetAllAvailableTimeForEachExam(int id);
        List<MyBooking> GetMyBooking(int userId);
    }
}
