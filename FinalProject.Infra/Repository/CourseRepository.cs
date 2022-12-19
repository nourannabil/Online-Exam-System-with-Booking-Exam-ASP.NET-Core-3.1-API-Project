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
    public class CourseRepository : IGenericRepository<CourseTable2> 
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(CourseTable2 courseTable)
        {
            var p = new DynamicParameters();
            p.Add("CNAME", courseTable.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPT", courseTable.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEP ", courseTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("COURSE_TABLE2_PACKAGE.CREATE_COURSE_TABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("COURSE_TABLE2_PACKAGE.DELETE_COURSE_TABLE2_ByID", p, commandType: CommandType.StoredProcedure);
        }

        public List<CourseTable2> GetAll()
        {
            IEnumerable<CourseTable2> result = _dbContext.Connection.Query<CourseTable2>("COURSE_TABLE2_PACKAGE.GETALL_COURSE_TABLE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public CourseTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CourseTable2> result = _dbContext.Connection.Query<CourseTable2>("COURSE_TABLE2_PACKAGE.GET_COURSE_TABLE2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(CourseTable2 courseTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", courseTable.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CNAME", courseTable.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPT", courseTable.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEP ", courseTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("COURSE_TABLE2_PACKAGE.UPDATE_COURSE_TABLE2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
