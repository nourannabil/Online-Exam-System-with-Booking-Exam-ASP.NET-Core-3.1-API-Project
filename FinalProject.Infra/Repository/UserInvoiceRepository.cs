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
    public class UserInvoiceRepository: IUserInvoiceRepository
    {
        private readonly IDbContext _dbContext;

        public UserInvoiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserInvoice> GetUserInvoice(int id)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<UserInvoice> result = _dbContext.Connection.Query<UserInvoice>("INVOICE_TABLE2_PACKAGE.GET_USER_INVOICE",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
