using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class CertificateService : IGenericService<ExamCertificate2>, ICertificateService
    {
        private readonly IGenericRepository<ExamCertificate2> _genericRepository;
        private readonly ICertificateRepository _certificateRepository;

        public CertificateService(IGenericRepository<ExamCertificate2> genericRepository, ICertificateRepository certificateRepository)
        {
            _genericRepository = genericRepository;
            _certificateRepository = certificateRepository;
        }

        public void Create(ExamCertificate2 examCertificate)
        {
            _genericRepository.Create(examCertificate);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<ExamCertificate2> GetAll()
        {
            return _genericRepository.GetAll(); 
        } 

        public ExamCertificate2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(ExamCertificate2 examCertificate)
        {
            _genericRepository.Update(examCertificate);
        }
        public List<MyCertificate> GetMyCertificate(int userId)
        {
            return _certificateRepository.GetMyCertificate(userId);
        }
    }
}
