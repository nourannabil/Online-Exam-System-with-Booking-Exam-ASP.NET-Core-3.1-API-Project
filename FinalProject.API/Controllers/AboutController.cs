using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : GenericController<AboutTable2>
    {
        public AboutController(IGenericService<AboutTable2> genericService) : base(genericService)
        {

        }

        [HttpPost]
        [Route("UplodeImage")]
        public AboutTable2 UplodeImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\hanee\\Downloads\\FinalAngular\\ExamBooking\\src\\assets\\images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            AboutTable2 about = new AboutTable2();
            about.Imagepath = fileName;
            return about;
        }
    }
}
