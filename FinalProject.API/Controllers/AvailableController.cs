using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableController : GenericController<AvaliableTable2> 
    {
        private readonly IAvailableService _availableService;
        public AvailableController(IGenericService<AvaliableTable2> genericService, IAvailableService availableService) : base(genericService)
        {
            _availableService = availableService;
        }

        [HttpGet]
        [Route("GetAllAvaliableTimeForEachExam/{examId}")]
        public List<AvaliableTable2> GetAllAvaliableTimeForEachExam(int examId)
        {
            return _availableService.GetAllAvaliableTimeForEachExam(examId);
        }

        [HttpPost]
        [Route("AddTimeForExam/{examId}")]
        public void AddTimeForExam(int examId, AvaliableTable2 avaliableTable)
        {
            _availableService.AddTimeForExam(examId, avaliableTable);
        }
    }
}
