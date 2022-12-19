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
    public class CertificateRepository : IGenericRepository<ExamCertificate2>, ICertificateRepository
    {
        private readonly IDbContext _dbContext;

        public CertificateRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ExamCertificate2 examCertificate)
        {
            var p = new DynamicParameters();
            p.Add("CERTIFICATE_TITLE", examCertificate.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CERTIFICATE_DESC", examCertificate.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", examCertificate.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UID", examCertificate.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BOOK_ID", examCertificate.Bookingid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("EXAM_CERTIFICATE2_PACKAGE.CREATE_EXAM_CERTIFICATE2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM_CERTIFICATE2_PACKAGE.DELETE_EXAM_CERTIFICATE2", p, commandType: CommandType.StoredProcedure);
        }

        public List<ExamCertificate2> GetAll()
        {
            IEnumerable<ExamCertificate2> result = _dbContext.Connection.Query<ExamCertificate2>("EXAM_CERTIFICATE2_PACKAGE.GETAll_EXAM_CERTIFICATE2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ExamCertificate2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ExamCertificate2> result = _dbContext.Connection.Query<ExamCertificate2>("EXAM_CERTIFICATE2_PACKAGE.GET_EXAM_CERTIFICATE2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(ExamCertificate2 examCertificate)
        {
            var p = new DynamicParameters();
            p.Add("ID", examCertificate.Certificateid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CERTIFICATE_TITLE", examCertificate.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CERTIFICATE_DESC", examCertificate.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", examCertificate.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UID", examCertificate.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BOOK_ID", examCertificate.Bookingid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("EXAM_CERTIFICATE2_PACKAGE.UPDATE_EXAM_CERTIFICATE2", p, commandType: CommandType.StoredProcedure);
        }

        public List<MyCertificate> GetMyCertificate(int userId)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MyCertificate> result = _dbContext.Connection.Query<MyCertificate>("EXAM_CERTIFICATE2_PACKAGE.GET_MY_CERTIFICATE", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
