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
    public class HomeRepository : IGenericRepository<HomeTable2>
    {
        private readonly IDbContext _dbContext;

        public HomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(HomeTable2 homeTable)
        {
            var p = new DynamicParameters();
            p.Add("IMAGE", homeTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_TITLE", homeTable.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_DESC_1", homeTable.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_DESC_2", homeTable.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_DESC_3", homeTable.Description3, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("HOME2_PACKAGE.CREATE_HOME2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("HOME2_PACKAGE.DELETE_HOME2", p, commandType: CommandType.StoredProcedure);
        }

        public List<HomeTable2> GetAll()
        {
            IEnumerable<HomeTable2> result = _dbContext.Connection.Query<HomeTable2>("HOME2_PACKAGE.GETAll_HOME2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public HomeTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<HomeTable2> result = _dbContext.Connection.Query<HomeTable2>("HOME2_PACKAGE.GET_HOME2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(HomeTable2 homeTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", homeTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMAGE", homeTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_TITLE", homeTable.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_DESC_1", homeTable.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_DESC_2", homeTable.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HOME_DESC_3", homeTable.Description3, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("HOME2_PACKAGE.UPDATE_HOME2", p, commandType: CommandType.StoredProcedure);

        }
    }
}
