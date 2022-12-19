using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class UserInvoiceService: IUserInvoiceService
    {
        private readonly IUserInvoiceRepository _userInvoiceRepository;

        public UserInvoiceService(IUserInvoiceRepository userInvoiceRepository)
        {
            _userInvoiceRepository = userInvoiceRepository;
        }

        public List<UserInvoice> GetUserInvoice(int id)
        {
           return _userInvoiceRepository.GetUserInvoice(id);
        }
    }
}
