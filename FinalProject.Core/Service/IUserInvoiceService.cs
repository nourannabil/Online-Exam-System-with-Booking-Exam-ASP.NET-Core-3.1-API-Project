using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Service
{
    public interface IUserInvoiceService
    {
        List<UserInvoice> GetUserInvoice(int id);
    }
}
