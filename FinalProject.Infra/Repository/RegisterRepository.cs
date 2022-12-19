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
    public class RegisterRepository : IRegisterRepository
    {
        private readonly IDbContext _dbContext;

        public RegisterRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public int Register(Register register)
        {
            var p = new DynamicParameters();
            p.Add("FIRST_NAME", register.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LAST_NAME", register.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", register.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_EMAIL", register.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ADDRESS", register.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", register.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.Execute("USER_TABLE2_PACKAGE.REGISTER", p, commandType: CommandType.StoredProcedure);
            
            int id = p.Get<int>("RESULT");

            register.UserId = id;

            return id;
        }


        public List<UserTable2> CheckUserName(string username)
        {
            var p = new DynamicParameters();
            p.Add("USER_NAME", username, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserTable2> result = _dbContext.Connection.Query<UserTable2>("LOGIN_TABLE2_PACKAGE.CHECK_USERNAME", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserTable2> CheckUserEmail(string useremail)
        {
            var p = new DynamicParameters();
            p.Add("USER_EMAIL", useremail, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserTable2> result = _dbContext.Connection.Query<UserTable2>("LOGIN_TABLE2_PACKAGE.CHECK_EMAIL", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
