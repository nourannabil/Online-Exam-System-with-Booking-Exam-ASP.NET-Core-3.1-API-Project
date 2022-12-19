using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : GenericController<QuestionBank2>
    {
        private readonly IQuestionBankService _questionBankService;
        public QuestionBankController(IGenericService<QuestionBank2> genericService , IQuestionBankService questionBankService) : base(genericService)
        {
            _questionBankService = questionBankService;
        }

        [HttpGet]
        [Route("GetRandomQuestionsByCourseId/{courseId}")]
        public List<QuestionBank2> GetRandomQuestionsByCourseId(int courseId)
        {
            return _questionBankService.GetRandomQuestionsByCourseId(courseId);
        }
    }
}
