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
    public class TestimonialRepository : IGenericRepository<TestimonialTable2>,ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TestimonialTable2 testimonialTable)
        {
            var p = new DynamicParameters();
            p.Add("FEED", testimonialTable.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATE_ID", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID", testimonialTable.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("HID", testimonialTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("TESTIMONIAL2_PACKAGE.CREATE_TESTIMONIAL2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("TESTIMONIAL2_PACKAGE.DELETE_TESTIMONIAL2", p, commandType: CommandType.StoredProcedure);
        }

        

        public List<TestimonialTable2> GetAll()
        {
            IEnumerable<TestimonialTable2> result = _dbContext.Connection.Query<TestimonialTable2>("TESTIMONIAL2_PACKAGE.GETALL_TESTIMONIAL2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public TestimonialTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TestimonialTable2> result = _dbContext.Connection.Query<TestimonialTable2>("TESTIMONIAL2_PACKAGE.GET_TESTIMONIAL2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(TestimonialTable2 testimonialTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", testimonialTable.Testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FEED", testimonialTable.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATE_ID", testimonialTable.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID", testimonialTable.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("HID", testimonialTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("TESTIMONIAL2_PACKAGE.UPDATE_TESTIMONIAL2", p, commandType: CommandType.StoredProcedure);
        }

        public List<TestimonialTable2> GetAcceptTestimonial()
        {
            IEnumerable<TestimonialTable2> result = _dbContext.Connection.Query<TestimonialTable2>("TESTIMONIAL2_PACKAGE.GET_ACCEPT_TESTIMONIAL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void AcceptTestimonial(int testId)
        {
            var p = new DynamicParameters();
            p.Add("TEST_ID", testId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("TESTIMONIAL2_PACKAGE.ACCEPT_TESTIMONIAL", p, commandType: CommandType.StoredProcedure);
        }

        public void RejectTestimonial(int testId)
        {
            var p = new DynamicParameters();
            p.Add("TEST_ID", testId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("TESTIMONIAL2_PACKAGE.REJECT_TESTIMONIAL", p, commandType: CommandType.StoredProcedure);
        }
    }
}
