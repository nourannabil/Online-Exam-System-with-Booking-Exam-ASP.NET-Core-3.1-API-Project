using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Repository
{
    public class StatisticsRepository: IStatisticsRepository
    {
        private readonly IDbContext _dbContext;

        public StatisticsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Statistics GetStatistics()
        {
            IEnumerable<Statistics> result = _dbContext.Connection.Query<Statistics>("ADMIN_STATISTICS.GET_STATISTCS",  commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
