using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : GenericController<ContactUsForm2>
    {
        public ContactFormController(IGenericService<ContactUsForm2> genericService) : base(genericService)
        {
        }
    }
}
