using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : GenericController<InvoiceTable2>
    {
        private readonly IUserInvoiceService _userInvoiceService;

        public InvoiceController(IGenericService<InvoiceTable2> genericService , IUserInvoiceService userInvoiceService) : base(genericService)
        {
            _userInvoiceService = userInvoiceService;
        }

        [HttpGet]
        [Route("GetUserInvoice/{id}")]
        public List<UserInvoice> GetUserInvoice(int id)
        {
            return _userInvoiceService.GetUserInvoice(id);
        }
    }
}
