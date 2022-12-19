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
    public class InvoiceRepository : IGenericRepository<InvoiceTable2>
    {
        private readonly IDbContext _dbContext;

        public InvoiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(InvoiceTable2 invoiceTable)
        {

            var p = new DynamicParameters();
            p.Add("TOTAL", invoiceTable.Totalprice, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("PDAY", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("VID", invoiceTable.Visaid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BID", invoiceTable.Bookingid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("INVOICE_TABLE2_PACKAGE.CREATE_INVOICE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("INVOICE_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("INVOICE_TABLE2_PACKAGE.DELETE_INVOICE2", p, commandType: CommandType.StoredProcedure);
        }

        public List<InvoiceTable2> GetAll()
        {
            IEnumerable<InvoiceTable2> result = _dbContext.Connection.Query<InvoiceTable2>("INVOICE_TABLE2_PACKAGE.GET_ALL_INVOICE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public InvoiceTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("INVOICE_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<InvoiceTable2> result = _dbContext.Connection.Query<InvoiceTable2>("INVOICE_TABLE2_PACKAGE.GET_INVOICE2_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(InvoiceTable2 invoiceTable)
        {
            var p = new DynamicParameters();
            p.Add("INVOICE_ID", invoiceTable.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TOTAL", invoiceTable.Totalprice, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("PDAY", invoiceTable.Paydate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("VID", invoiceTable.Visaid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BID", invoiceTable.Bookingid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("INVOICE_TABLE2_PACKAGE.UPDATE_INVOICE2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
