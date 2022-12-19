using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class ExamService : IGenericService<Exam2>,IExamService
    {
        private readonly IGenericRepository<Exam2> _genericRepository;
        private readonly IExamRepository _examRepository;

        public ExamService(IGenericRepository<Exam2> genericRepository, IExamRepository examRepository)
        {
            _genericRepository = genericRepository;
            _examRepository = examRepository;
        }

        public void Create(Exam2 exam)
        {
            _genericRepository.Create(exam);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<Exam2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public Exam2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(Exam2 exam)
        {
            _genericRepository.Update(exam);
        }

        public List<Exam2> SearchByExamName(string name)
        {
            return _examRepository.SearchByExamName(name);
        }

        public List<Exam2> GetExamFromCourse(int id)
        {
            return _examRepository.GetExamFromCourse(id);
        }

        public List<DateTime?> GetAllAvaliableTimeForEeachExam(int id)
        {
            return _examRepository.GetAllAvaliableTimeForEeachExam(id);
        }
    }
}
