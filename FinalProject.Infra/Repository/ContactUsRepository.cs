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
    public class ContactUsRepository : IGenericRepository<ContactUsTable2>
    {
        private readonly IDbContext _dbContext;

        public ContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ContactUsTable2 contactUsTable)
        {
            var p = new DynamicParameters();
            p.Add("IMAGE", contactUsTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTACT_TITLE", contactUsTable.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESC1", contactUsTable.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESC2", contactUsTable.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESC3", contactUsTable.Description3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAPP", contactUsTable.Map, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HID", contactUsTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CONTACTUS2_PACKAGE.CREATE_CONTACT2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("CONTACTUS2_PACKAGE.DELETE_CONTACT2", p, commandType: CommandType.StoredProcedure);
        }

        public List<ContactUsTable2> GetAll()
        {
            IEnumerable<ContactUsTable2> result = _dbContext.Connection.Query<ContactUsTable2>("CONTACTUS2_PACKAGE.GETALL_CONTACT2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ContactUsTable2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ContactUsTable2> result = _dbContext.Connection.Query<ContactUsTable2>("CONTACTUS2_PACKAGE.GET_CONTACT2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(ContactUsTable2 contactUsTable)
        {
            var p = new DynamicParameters();
            p.Add("ID", contactUsTable.Contacttableid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMAGE", contactUsTable.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTACT_TITLE", contactUsTable.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESC1", contactUsTable.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESC2", contactUsTable.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESC3", contactUsTable.Description3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAPP", contactUsTable.Map, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HID", contactUsTable.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CONTACTUS2_PACKAGE.UPDATE_CONTACT2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
