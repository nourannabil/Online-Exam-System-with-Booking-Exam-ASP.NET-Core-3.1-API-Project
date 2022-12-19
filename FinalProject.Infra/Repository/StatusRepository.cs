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
    public class StatusRepository : IGenericRepository<StatusTable2>
    {
        private readonly IDbContext _dbContext;

        public StatusRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Create(StatusTable2 statusTable)
        {
            var p = new DynamicParameters();
            p.Add("STATUS", statusTable.Statusname, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("STATUS2_PACKAGE.CREATE_STATUS2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("STATUS2_PACKAGE.DELETE_STATUS2", p, commandType: CommandType.StoredProcedure);
        }

        public List<StatusTable2> GetAll()
        {
            IEnumerable<StatusTable2> result = _dbContext.Connection.Query<StatusTable2>("STATUS2_PACKAGE.GETALL_STATUS2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public StatusTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<StatusTable2> result = _dbContext.Connection.Query<StatusTable2>("STATUS2_PACKAGE.GET_STATUS2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(StatusTable2 statusTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", statusTable.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATUS", statusTable.Statusname, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("STATUS2_PACKAGE.UPDATE_STATUS2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
