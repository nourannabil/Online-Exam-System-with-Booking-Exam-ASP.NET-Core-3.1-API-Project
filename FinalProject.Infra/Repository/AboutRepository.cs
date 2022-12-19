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
    public class AboutRepository : IGenericRepository<AboutTable2>
    {
        private readonly IDbContext _dbContext;

        public AboutRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(AboutTable2 aboutTable)
        {
            var p = new DynamicParameters();
            p.Add("IMAGE", aboutTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABOUT_TITLE", aboutTable.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABOUT_DESC_1", aboutTable.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABOUT_DESC_2", aboutTable.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HID", aboutTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("ABOUT2_PACKAGE.CREATE_ABOUT2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ABOUT2_PACKAGE.DELETE_ABOUT2", p, commandType: CommandType.StoredProcedure);
        }

        public List<AboutTable2> GetAll()
        {
            IEnumerable<AboutTable2> result = _dbContext.Connection.Query<AboutTable2>("ABOUT2_PACKAGE.GETAll_ABOUT2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public AboutTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AboutTable2> result = _dbContext.Connection.Query<AboutTable2>("ABOUT2_PACKAGE.GET_ABOUT2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(AboutTable2 aboutTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", aboutTable.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMAGE", aboutTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABOUT_TITLE", aboutTable.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABOUT_DESC_1", aboutTable.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABOUT_DESC_2", aboutTable.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HID", aboutTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("ABOUT2_PACKAGE.UPDATE_ABOUT2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
