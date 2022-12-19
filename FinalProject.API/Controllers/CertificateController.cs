using FinalProject.Core.Data;
using FinalProject.Core.DTO;
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
    public class CertificateController : GenericController<ExamCertificate2>
    {
        private readonly ICertificateService _certificateService;
        public CertificateController(IGenericService<ExamCertificate2> genericService, ICertificateService certificateService) : base(genericService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        [Route("GetMyCertificate/{userId}")]
        public List<MyCertificate> GetMyCertificate(int userId)
        {
            return _certificateService.GetMyCertificate(userId);
        }

        [HttpPost]
        [Route("UplodeImage")]
        public ExamCertificate2 UplodeImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\hanee\\Downloads\\FinalAngular\\ExamBooking\\src\\assets\\images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            ExamCertificate2 certificate = new ExamCertificate2();
            certificate.Imagepath = fileName;
            return certificate;
        }
    }
}
