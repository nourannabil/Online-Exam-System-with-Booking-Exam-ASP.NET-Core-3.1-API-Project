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
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(UserTable2 userTable)
        {
            var p = new DynamicParameters();
            p.Add("FIRST_NAME", userTable.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LAST_NAME", userTable.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", userTable.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_EMAIL", userTable.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ADDRESS", userTable.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", userTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("USER_TABLE2_PACKAGE.CREATE_USER_TABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("USER_TABLE2_PACKAGE.DELETE_USER_TABLE2_ByID", p, commandType: CommandType.StoredProcedure);
        }

        public List<UserTable2> GetAll()
        {
            IEnumerable<UserTable2> result = _dbContext.Connection.Query<UserTable2>("USER_TABLE2_PACKAGE.GETALL_USER_TABLE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public UserTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<UserTable2> result = _dbContext.Connection.Query<UserTable2>("USER_TABLE2_PACKAGE.GET_USER_TABLE2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
      
        public void Update(UserTable2 userTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", userTable.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FIRST_NAME", userTable.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LAST_NAME", userTable.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", userTable.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_EMAIL", userTable.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ADDRESS", userTable.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", userTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("USER_TABLE2_PACKAGE.UPDATE_USER_TABLE2", p, commandType: CommandType.StoredProcedure);
        }

        public UserTable2 GetMyProfile(int userId)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<UserTable2> result = _dbContext.Connection.Query<UserTable2>("USER_TABLE2_PACKAGE.GET_MY_PROFILE", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void EditMyProfile(int userId , UserTable2 userTable)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FIRST_NAME", userTable.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LAST_NAME", userTable.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", userTable.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_EMAIL", userTable.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ADDRESS", userTable.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", userTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("USER_TABLE2_PACKAGE.EDIT_MY_PROFILE", p, commandType: CommandType.StoredProcedure);
        }
    }
}
