using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FinalProject.Infra.Repository
{
    public class EmailRepository: IEmailRepository
    {
       
        private readonly IGenericRepository<ExamBooking2> _genericBookingRepository;
        private readonly IGenericRepository<UserTable2> _genericUserRepository;
        private readonly IGenericRepository<Exam2> _genericExamRepository;

        public EmailRepository(IGenericRepository<ExamBooking2> genericBookingRepository, IGenericRepository<UserTable2> genericUserRepository, IGenericRepository<Exam2> genericExamRepository)
        {

            _genericBookingRepository = genericBookingRepository;
            _genericUserRepository = genericUserRepository;
            _genericExamRepository = genericExamRepository;
        }

        public void SendEmail(int id)
        {
            
            string password;
           
            var bookings = _genericBookingRepository.GetAll().ToList();
            var Users = _genericUserRepository.GetAll().ToList();
            var Exams = _genericExamRepository.GetAll().ToList();

            foreach (var booking in bookings)
            {
                if (booking.Bookingid == id)
                {
                    password = booking.Exampassword;

                    foreach(var user in Users)
                    {
                        if (user.Userid == booking.Userid) 
                        {
                            foreach (var exam in Exams)
                            {
                                if (exam.Examid == booking.Examid)
                                {
                                    SmtpClient Client = new SmtpClient("smtp.office365.com");
                                    Client.Port = 587;
                                    Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    Client.UseDefaultCredentials = false;
                                    NetworkCredential credential = new NetworkCredential("exam.booking@outlook.com", "finalproject11");
                                    Client.EnableSsl = true;
                                    Client.Credentials = credential;

                                    MailMessage message = new MailMessage("exam.booking@outlook.com", user.Email);
                                    message.Subject = "Exam Details";


                                    message.Body = @"<html><head>
                                                    <style>
                                                      .pclass{text-transform:capitalize}
                                                    </style>
                                                     </head> 
                                                      <body>" + "<p class=pclass>" + "Dear "
                                                      + user.Fname + " " + user.Lname  +",</p>"+
                                                      "<p>Greetings from Exam Booking Center<p> "+
                                                       "<p> Thank you for trust us </br>" +
                                                       "you have successfully book " + " " + "<strong>" + exam.Name + " " + "Exam" + "</strong>" + "</br>" +
                                                       " Your exam will be on " + "<strong>" + booking.Examdateuser + "</strong>" + "</br>" +
                                                       " before starting the exam you have to enter this password " + "<strong>" + password + "</strong>"  + "</p>"+
                                                       "<p> Best Wishes! </p>" +
                                                       "<p>Exam Booking Center</p>" +
                                                       "Mobile:+962786573879"+
                                                       "</ body></html>";
          
                                    message.IsBodyHtml = true;
                                    Client.Send(message);
                                }
                            }
                            
                        }
                       
                    }
                }
            }  
        }
    }
}
