using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDbContext _dbContext;

        public ReportRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExamBooking2> GetReport(DateTime? dateFrom, DateTime? dateTo, string year)
        {
            var p = new DynamicParameters();
            p.Add("DATEFROM", dateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DATETO", dateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("YEARR", year, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<ExamBooking2> result = _dbContext.Connection.Query<ExamBooking2>("ADMIN_STATISTICS.GET_STATISTCS_FOR_REPORT", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
