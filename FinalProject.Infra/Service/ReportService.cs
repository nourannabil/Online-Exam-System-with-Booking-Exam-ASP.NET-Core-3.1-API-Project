using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using FinalProject.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<ExamBooking2> GetReport(DateTime? dateFrom, DateTime? dateTo, string year)
        {
            return _reportRepository.GetReport(dateFrom, dateTo, year);
           
        }
    }
}
