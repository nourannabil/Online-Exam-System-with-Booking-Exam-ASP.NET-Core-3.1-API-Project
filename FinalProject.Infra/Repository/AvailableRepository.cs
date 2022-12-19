using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Repository
{
    public class AvailableRepository : IGenericRepository<AvaliableTable2> , IAvailableRepository
    {
        private readonly IDbContext _dbContext;

        public AvailableRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(AvaliableTable2 avaliableTable)
        {
            var p = new DynamicParameters();
            p.Add("START_DATE", avaliableTable.Examstartdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EID", avaliableTable.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATE_ID",3, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("AVAILABLE_TABLE_PACKAGE2.CREATE_AVAILABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("AVAILABLE_TABLE_PACKAGE2.DELETE_AVAILABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public List<AvaliableTable2> GetAll()
        {
            IEnumerable<AvaliableTable2> result = _dbContext.Connection.Query<AvaliableTable2>("AVAILABLE_TABLE_PACKAGE2.GET_ALL_AVAILABLE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public AvaliableTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AvaliableTable2> result = _dbContext.Connection.Query<AvaliableTable2>("AVAILABLE_TABLE_PACKAGE2.GET_AVAILABLE2_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(AvaliableTable2 avaliableTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", avaliableTable.Avaliableid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("START_DATE", avaliableTable.Examstartdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EID", avaliableTable.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATE_ID", avaliableTable.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("AVAILABLE_TABLE_PACKAGE2.UPDATE_AVAILABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public List<AvaliableTable2> GetAllAvaliableTimeForEachExam(int examId)
        {
            var p = new DynamicParameters();
            p.Add("EXAM_NUM", examId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AvaliableTable2> result = _dbContext.Connection.Query<AvaliableTable2>("AVAILABLE_TABLE_PACKAGE2.GetALL_AVALIABLE_TIME_FOR_EACH_EXAM", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void AddTimeForExam(int examId, AvaliableTable2 avaliableTable)
        {
            var p = new DynamicParameters();
            p.Add("START_DATE", avaliableTable.Examstartdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("EID", examId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATE_ID", 3, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("AVAILABLE_TABLE_PACKAGE2.CREATE_AVAILABLE2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
