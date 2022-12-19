using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Service
{
    public interface IQuestionBankService
    {
        List<QuestionBank2> GetRandomQuestionsByCourseId(int courseId);
    }
}
