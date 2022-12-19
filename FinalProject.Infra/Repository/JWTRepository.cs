using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Repository
{
    public class JWTRepository: IJWTRepository
    {

        private readonly IDbContext _dbContext;

        public JWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JWT UserLogin(JWT jwt)
        {
            var p = new DynamicParameters();
            p.Add("USER_NAME", jwt.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", jwt.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<JWT> result = _dbContext.Connection.Query<JWT>("LOGIN_TABLE2_PACKAGE.LOGIN_JWT", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
    
}
