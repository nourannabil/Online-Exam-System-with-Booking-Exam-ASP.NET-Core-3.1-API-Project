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
    public class VisaRepository : IGenericRepository<VisaTable2>
    {
        private readonly IDbContext _dbContext;

        public VisaRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(VisaTable2 visaTable)
        {
            var p = new DynamicParameters();
            p.Add("CARD_NUM", visaTable.Cardnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CVC_NUM", visaTable.Cvc, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EXPDATE", visaTable.Expirydate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("VISA_BALANCE", visaTable.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("VISA_TABLE2_PACKAGE.CREATE_VISA2", p, commandType: CommandType.StoredProcedure);
        }
        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("VISA_TABLE2_PACKAGE.DELETE_VISA2", p, commandType: CommandType.StoredProcedure);
        }

        public List<VisaTable2> GetAll()
        {
            IEnumerable<VisaTable2> result = _dbContext.Connection.Query<VisaTable2>("VISA_TABLE2_PACKAGE.GET_ALL_VISA2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public VisaTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<VisaTable2> result = _dbContext.Connection.Query<VisaTable2>("VISA_TABLE2_PACKAGE.GET_VISA2_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(VisaTable2 visaTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", visaTable.Visaid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CARD_NUM", visaTable.Cardnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CVC_NUM", visaTable.Cvc, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EXPDATE", visaTable.Expirydate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("VISA_BALANCE", visaTable.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("VISA_TABLE2_PACKAGE.UPDATE_VISA2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
