using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : GenericController<ContactUsTable2>
    {
        public ContactUsController(IGenericService<ContactUsTable2> genericService) : base(genericService)
        {
        }


        [HttpPost]
        [Route("UplodeImage")]
        public ContactUsTable2 UplodeImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\hanee\\Downloads\\FinalAngular\\ExamBooking\\src\\assets\\images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            ContactUsTable2 contactUs = new ContactUsTable2();
            contactUs.Imagepath = fileName;
            return contactUs;
        }
    }
}
