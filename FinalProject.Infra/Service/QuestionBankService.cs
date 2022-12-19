using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class QuestionBankService : IGenericService<QuestionBank2> , IQuestionBankService
    {
        private readonly IGenericRepository<QuestionBank2> _genericRepository;
        private readonly IQuestionBankRepository _questionBankRepository;

        public QuestionBankService(IGenericRepository<QuestionBank2> genericRepository , IQuestionBankRepository questionBankRepository)
        {
            _genericRepository = genericRepository;
            _questionBankRepository = questionBankRepository;
        }

        public void Create(QuestionBank2 questionBank)
        {
            _genericRepository.Create(questionBank);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<QuestionBank2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public QuestionBank2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(QuestionBank2 questionBank)
        {
            _genericRepository.Update(questionBank);
        }

        public List<QuestionBank2> GetRandomQuestionsByCourseId(int courseId)
        {
            return _questionBankRepository.GetRandomQuestionsByCourseId(courseId);
        }
    }
}
