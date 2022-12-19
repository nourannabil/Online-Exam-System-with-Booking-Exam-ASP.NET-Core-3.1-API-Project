using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("GetReport/{dateFrom}/{dateTo}/{year}")]
        public List<ExamBooking2> GetReport(DateTime? dateFrom, DateTime? dateTo, string year)
        {
            return _reportService.GetReport(dateFrom, dateTo, year);
        }
    }
}
