using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : GenericController<TestimonialTable2>
    {
        private readonly ITestimonialService _testimonialService;   
        public TestimonialController(IGenericService<TestimonialTable2> genericService, ITestimonialService testimonialService) : base(genericService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        [Route("GetAcceptTestimonial")]
        public List<TestimonialTable2> GetAcceptTestimonial()
        {
            return _testimonialService.GetAcceptTestimonial();
        }
        [HttpGet]
        [Route("Accept/{testId}")]
        public void AcceptTestimonial(int testId)
        {
            _testimonialService.AcceptTestimonial(testId);
        }

        [HttpGet]
        [Route("Reject/{testId}")]
        public void RejectTestimonial(int testId)
        {
            _testimonialService.RejectTestimonial(testId);
        }
    }
}
