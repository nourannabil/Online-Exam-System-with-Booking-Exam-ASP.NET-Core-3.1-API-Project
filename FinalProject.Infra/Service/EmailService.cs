using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class EmailService: IEmailService
    {
        private readonly IEmailRepository _EmailRepository;

        public EmailService(IEmailRepository EmailRepository)
        {
            _EmailRepository = EmailRepository;


        }

        public void SendEmail(int id)
        {
            _EmailRepository.SendEmail(id);
        }
    }
}
