using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IUserInvoiceRepository
    {
        List<UserInvoice> GetUserInvoice(int id);
    }
}
