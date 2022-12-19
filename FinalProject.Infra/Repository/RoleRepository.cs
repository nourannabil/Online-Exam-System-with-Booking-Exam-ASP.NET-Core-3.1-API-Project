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
    public class RoleRepository:IGenericRepository<RoleTable2>
    {

        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(RoleTable2 roletable)
        {
            var p = new DynamicParameters();
            p.Add("RNAME", roletable.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ROLE_TABLE2_PACKAGE.CREATE_ROLE_TABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ROLE_TABLE2_PACKAGE.DELETE_ROLE_TABLE2_ByID", p, commandType: CommandType.StoredProcedure);
        }


        public List<RoleTable2> GetAll()
        {
            IEnumerable<RoleTable2> result = _dbContext.Connection.Query<RoleTable2>("ROLE_TABLE2_PACKAGE.GETALL_ROLE_TABLE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public RoleTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<RoleTable2> result = _dbContext.Connection.Query<RoleTable2>("ROLE_TABLE2_PACKAGE.GET_ROLE_TABLE2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public void Update(RoleTable2 roletable)
        {
            var p = new DynamicParameters();
            p.Add("ID", roletable.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RNAME", roletable.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ROLE_TABLE2_PACKAGE.UPDATE_ROLE_TABLE2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
