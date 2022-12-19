using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IQuestionBankRepository
    {
        List<QuestionBank2> GetRandomQuestionsByCourseId(int courseId);

    }
}
