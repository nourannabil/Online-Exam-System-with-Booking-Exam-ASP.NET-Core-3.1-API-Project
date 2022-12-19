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
    public class ContactFormRepository : IGenericRepository<ContactUsForm2>
    {
        private readonly IDbContext _dbContext;

        public ContactFormRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ContactUsForm2 contactForm)
        {
            var p = new DynamicParameters();
            p.Add("FNAME", contactForm.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTACT_EMAIL", contactForm.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MSG", contactForm.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HID", contactForm.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CONTACT_FORM2_PACKAGE.CREATE_CONTACT_FORM2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("CONTACT_FORM2_PACKAGE.DELETE_CONTACT_FORM2", p, commandType: CommandType.StoredProcedure);
        }

        public List<ContactUsForm2> GetAll()
        {
            IEnumerable<ContactUsForm2> result = _dbContext.Connection.Query<ContactUsForm2>("CONTACT_FORM2_PACKAGE.GETALL_CONTACT_FORM2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ContactUsForm2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ContactUsForm2> result = _dbContext.Connection.Query<ContactUsForm2>("CONTACT_FORM2_PACKAGE.GET_CONTACT_FORM2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(ContactUsForm2 contactForm)
        {
            var p = new DynamicParameters();
            p.Add("ID", contactForm.Contactformid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FNAME", contactForm.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTACT_EMAIL", contactForm.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MSG", contactForm.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("HID", contactForm.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CONTACT_FORM2_PACKAGE.UPDATE_CONTACT_FORM2", p, commandType: CommandType.StoredProcedure);
        }
    }
}
