using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : GenericController<Exam2>
    {
        public readonly IExamService _examService;
        public ExamController(IGenericService<Exam2> genericService , IExamService examService) : base(genericService)
        {
            _examService = examService;
        }

        [HttpGet]
        [Route("GetExamByName/{name}")]
        public List<Exam2> SearchByExamName(string name)
        {
            return _examService.SearchByExamName(name);
        }

        [HttpGet]
        [Route("GetExamByCourseId/{id}")]
        public List<Exam2> GetExamFromCourse(int id)
        {
            return _examService.GetExamFromCourse(id);
        }

        [HttpGet]
        [Route("GetAllAvaliableTimeForEeachExam/{id}")]
        public List<DateTime?> GetAllAvaliableTimeForEeachExam(int id)
        {
            return _examService.GetAllAvaliableTimeForEeachExam(id);
        }

        [HttpPost]
        [Route("UplodeImage")]
        public Exam2 UplodeImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\hanee\\Downloads\\FinalAngular\\ExamBooking\\src\\assets\\images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Exam2 exam = new Exam2();
            exam.Imagepath = fileName;
            return exam;
        }
    }
}
