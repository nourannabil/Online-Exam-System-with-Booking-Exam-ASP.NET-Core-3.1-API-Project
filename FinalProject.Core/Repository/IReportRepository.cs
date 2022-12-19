using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IReportRepository
    {
        List<ExamBooking2> GetReport(DateTime? dateFrom, DateTime? dateTo, string year);
    }
}
