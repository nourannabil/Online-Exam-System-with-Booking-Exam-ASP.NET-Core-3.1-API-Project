using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class BookingService : IGenericService<ExamBooking2>, IBookingService
    {
        
        private readonly IGenericRepository<ExamBooking2> _genericRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IGenericRepository<ExamBooking2> genericRepository, IBookingRepository bookingRepository)
        {
            _genericRepository = genericRepository;
            _bookingRepository=bookingRepository;
        }

        public void Create(ExamBooking2 examBooking)
        {
            _genericRepository.Create(examBooking);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<ExamBooking2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public ExamBooking2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(ExamBooking2 examBooking)
        {
            _genericRepository.Update(examBooking);
        }
        public List<ExamBooking2> SearchBetweenTwoDate(DateTime? dateFrom, DateTime? dateTo)
        {
            return _bookingRepository.SearchBetweenTwoDate(dateFrom, dateTo);
        }

        public List<DateTime?> GetAllAvailableTimeForEachExam(int id)
        {
            return _bookingRepository.GetAllAvailableTimeForEachExam(id);
        }

        public List<MyBooking> GetMyBooking(int userId)
        {
            return _bookingRepository.GetMyBooking(userId);
        }
    }
}
