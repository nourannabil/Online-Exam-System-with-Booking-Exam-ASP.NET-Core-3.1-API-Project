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
    public class BookingRepository : IGenericRepository<ExamBooking2>, IBookingRepository
    {
        //IGenericRepository<ExamBooking2>, 
        private readonly IDbContext _dbContext;

        public BookingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ExamBooking2 examBooking)
        {
            
            Random random = new Random();
            var p = new DynamicParameters();
            p.Add("USERDATE", examBooking.Examdateuser, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("BDATE", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("PASS", random.Next(100000), dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EID", examBooking.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID", examBooking.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATE_ID", examBooking.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM_BOOKING2_PACKAGE.CREATE_EXAM_BOOKING2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM_BOOKING2_PACKAGE.DELETE_EXAM_BOOKING2", p, commandType: CommandType.StoredProcedure);
        }

        public List<ExamBooking2> GetAll()
        {
            IEnumerable<ExamBooking2> result = _dbContext.Connection.Query<ExamBooking2>("EXAM_BOOKING2_PACKAGE.GET_ALL_EXAM_BOOKING2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public ExamBooking2 GetById(int id)
        {

            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ExamBooking2> result = _dbContext.Connection.Query<ExamBooking2>("EXAM_BOOKING2_PACKAGE.GET_BOOKING2_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }   

        public void Update(ExamBooking2 examBooking)
        {
            var p = new DynamicParameters();
            p.Add("ID", examBooking.Bookingid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERDATE", examBooking.Examdateuser, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("BDATE", examBooking.Bookingdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("PASS", examBooking.Exampassword, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EID", examBooking.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID", examBooking.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATE_ID", examBooking.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM_BOOKING2_PACKAGE.UPDATE_EXAM_BOOKING2", p, commandType: CommandType.StoredProcedure);
        }

        public List<ExamBooking2> SearchBetweenTwoDate(DateTime? dateFrom, DateTime? dateTo)
        {
            var p = new DynamicParameters();
            p.Add("DATEFROM", dateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DATETO", dateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<ExamBooking2> result = _dbContext.Connection.Query<ExamBooking2>("EXAM_BOOKING2_PACKAGE.SEARCH_BETWEEN_TWO_DATE", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<DateTime?> GetAllAvailableTimeForEachExam(int id)
        {
            
            var p = new DynamicParameters();
            p.Add("EXAM_NUM", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AvaliableTable2> result = _dbContext.Connection.Query<AvaliableTable2>("EXAM_BOOKING2_PACKAGE.GetALL_AVALIABLE_TIME_FOR_EACH_EXAM", p, commandType: CommandType.StoredProcedure);
            var finalResult = result.Where<AvaliableTable2>(x => x.Statusid == 3).Select(x=>x.Examstartdate).ToList();
            return finalResult.ToList();
        }

        public List<MyBooking> GetMyBooking(int userId)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MyBooking> result = _dbContext.Connection.Query<MyBooking>("EXAM_BOOKING2_PACKAGE.GET_MY_BOOKING", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
