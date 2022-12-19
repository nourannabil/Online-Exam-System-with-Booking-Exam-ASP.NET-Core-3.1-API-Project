using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : GenericController<CourseTable2>
    {
        public CourseController(IGenericService<CourseTable2> genericService) : base(genericService)
        {

        }

        [HttpPost]
        [Route("UplodeImage")]
        public CourseTable2 UplodeImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\hanee\\Downloads\\FinalAngular\\ExamBooking\\src\\assets\\images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            CourseTable2 course = new CourseTable2();
            course.Imagepath = fileName;
            return course;
        }
    }
}
