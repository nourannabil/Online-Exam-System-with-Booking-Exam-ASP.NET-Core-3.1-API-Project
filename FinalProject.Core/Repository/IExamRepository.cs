using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IExamRepository
    {
        List<Exam2> SearchByExamName(string name);
        List<Exam2> GetExamFromCourse(int id);
        List<DateTime?> GetAllAvaliableTimeForEeachExam(int id);
    }
}
