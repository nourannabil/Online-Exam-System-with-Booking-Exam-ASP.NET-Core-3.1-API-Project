using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class BookingCycleService:IBookingCycleService
    {
        private readonly IBookingCycleRepository _bookingCycleRepository;
        private readonly IGenericRepository<Exam2> _examRepository;
        private readonly IGenericRepository<VisaTable2> _visaRepository;
        private readonly IGenericRepository<AvaliableTable2> _availableRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IGenericRepository<InvoiceTable2> _InvoiceRepository;
        private readonly IGenericRepository<ExamBooking2> _genericBookingRepository;
        private readonly IEmailRepository _emailRepository;

        public BookingCycleService(IBookingCycleRepository bookingCycleRepository, 
            IGenericRepository<Exam2> examRepository, IGenericRepository<VisaTable2> visaRepository,
            IGenericRepository<AvaliableTable2> availableRepository, IGenericRepository<InvoiceTable2> invoiceRepository,
            IBookingRepository bookingRepository, IGenericRepository<ExamBooking2> genericBookingRepository
            , IEmailRepository emailRepository)
        {
            _bookingCycleRepository = bookingCycleRepository;
            _examRepository = examRepository;
            _visaRepository = visaRepository;
            _availableRepository = availableRepository;
            _InvoiceRepository = invoiceRepository;
            _bookingRepository = bookingRepository;
            _genericBookingRepository = genericBookingRepository;
            _emailRepository = emailRepository;
        }

        public void BookingCycle( BookingCycle bookingCycle)
        {
            var Visas = _visaRepository.GetAll().ToList();
            bool findVisa=false;
            double newBalance;
            int userVisaId=0;
            double examprice = 0;
            double balance = 0;

            foreach (var visa in Visas)
            {
                if(visa.Cardnumber==bookingCycle.Cardnumber&& visa.Cvc==bookingCycle.Cvc&& visa.Expirydate==bookingCycle.Expirydate && visa.Expirydate>=DateTime.Now)
                {
                    balance = (double)visa.Balance; // i dont want from the user to insert his visa balance
                    findVisa = true; // Check Visa information 
                }
            }

            if (findVisa == true)
            {
                var exams=_examRepository.GetAll().ToList();
                
                foreach (var exam in exams)
                {
                    if (exam.Examid == bookingCycle.Examid)
                    {
                        examprice = (double)exam.Examprice; // to get the exam price that we book it now  
                    }
                }

                // here will start create booking when the blance in enoguh 
                if (balance >= examprice)
                {
                    _bookingCycleRepository.BookingCycle(bookingCycle);

                    var availableTimes= _availableRepository.GetAll().ToList();

                    foreach (var available in availableTimes)
                    {
                        if(available.Examid==bookingCycle.Examid && available.Examstartdate == bookingCycle.Examdateuser)
                        {
                            available.Statusid = 4; // Here will change the status of the booked date to (not avalible); to not Show in the list again 
                            _availableRepository.Update(available);
                            _availableRepository.Delete((int)available.Avaliableid);
                        }
                    }
                    foreach (var visa in Visas)
                    {
                        // here will check the visa information again to update the blance after paid 
                        if (visa.Cardnumber == bookingCycle.Cardnumber && visa.Cvc == bookingCycle.Cvc && visa.Expirydate == bookingCycle.Expirydate )
                        {
                            
                            userVisaId = (int)visa.Visaid;
                            newBalance =(double) visa.Balance - examprice;

                            visa.Balance = (int)newBalance; 
                            _visaRepository.Update(visa);
                        }
                    }
                    // here will create the invoice after paid 
                    InvoiceTable2 userInvoice=new InvoiceTable2();
                     userInvoice.Totalprice =(decimal)(balance-examprice);
                    userInvoice.Paydate = DateTime.Now;
                    userInvoice.Visaid = userVisaId;
                    userInvoice.Bookingid = bookingCycle.BookId;
                    _InvoiceRepository.Create(userInvoice);

                    // Generate Random Password 
                    var bookings = _genericBookingRepository.GetAll().ToList();
                    string password ;
                    foreach(var booking in bookings)
                    {
                        if(booking.Bookingid == bookingCycle.BookId)
                        {
                            password = booking.Exampassword;
                        }
                    }

                    //Last step pass the password to email function 
                   _emailRepository.SendEmail(bookingCycle.BookId);

                }
            }
        }
    }
}
