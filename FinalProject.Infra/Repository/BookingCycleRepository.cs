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
    public class BookingCycleRepository : IBookingCycleRepository
    {
        private readonly IDbContext _dbContext;

        public BookingCycleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int BookingCycle(BookingCycle bookingCycle)//add exam id parameter
        {   
            Random random = new Random();  
            var p = new DynamicParameters();
            p.Add("USERDATE", bookingCycle.Examdateuser, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("BDATE", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("PASS", random.Next(100000), dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EID", bookingCycle.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UID", bookingCycle.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STATE_ID", 5, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.Execute("EXAM_BOOKING2_PACKAGE.BOOK_NOW", p, commandType: CommandType.StoredProcedure);

            int id = p.Get<int>("RESULT");

            bookingCycle.BookId = id;

            return id;
        }

    }
}
