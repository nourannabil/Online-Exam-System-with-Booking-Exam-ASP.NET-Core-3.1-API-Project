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
    public class LoginRepository : IGenericRepository<LoginTable2>
    {
        private readonly IDbContext _dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(LoginTable2 loginTable)
        {
            var p = new DynamicParameters();
            p.Add("UNAME", loginTable.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", loginTable.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RID ", loginTable.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID ", loginTable.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("LOGIN_TABLE2_PACKAGE.CREATE_LOGIN_TABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("LOGIN_TABLE2_PACKAGE.DELETE_LOGIN_TABLE2_ByID", p, commandType: CommandType.StoredProcedure);
        }

        public List<LoginTable2> GetAll()
        {
            IEnumerable<LoginTable2> result = _dbContext.Connection.Query<LoginTable2>("LOGIN_TABLE2_PACKAGE.GETALL_LOGIN_TABLE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public LoginTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<LoginTable2> result = _dbContext.Connection.Query<LoginTable2>("LOGIN_TABLE2_PACKAGE.GET_LOGIN_TABLE2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(LoginTable2 loginTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", loginTable.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UNAME", loginTable.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", loginTable.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RID ", loginTable.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID ", loginTable.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("LOGIN_TABLE2_PACKAGE.UPDATE_LOGIN_TABLE2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
