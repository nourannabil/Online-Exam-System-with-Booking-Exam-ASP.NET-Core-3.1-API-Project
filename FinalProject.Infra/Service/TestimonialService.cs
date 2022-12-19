using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using FinalProject.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class TestimonialService : IGenericService<TestimonialTable2>,ITestimonialService
    {
        private readonly IGenericRepository<TestimonialTable2> _genericRepository;
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(IGenericRepository<TestimonialTable2> genericRepository, ITestimonialRepository testimonialRepository)
        {
            _genericRepository = genericRepository;
            _testimonialRepository = testimonialRepository;
        }
        public void Create(TestimonialTable2 testimonialTable)
        {
            _genericRepository.Create(testimonialTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<TestimonialTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public TestimonialTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(TestimonialTable2 testimonialTable)
        {
            _genericRepository.Update(testimonialTable);
        }

        public List<TestimonialTable2> GetAcceptTestimonial()
        {
            return _testimonialRepository.GetAcceptTestimonial();
        }

        public void AcceptTestimonial(int testId)
        {
            _testimonialRepository.AcceptTestimonial(testId);
        }

        public void RejectTestimonial(int testId)
        {
            _testimonialRepository.RejectTestimonial(testId);
        }
    }
}
