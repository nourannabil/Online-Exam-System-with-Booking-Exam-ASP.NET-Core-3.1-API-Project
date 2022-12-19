using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IAvailableRepository
    {
       List<AvaliableTable2> GetAllAvaliableTimeForEachExam(int examId);
       void AddTimeForExam (int examId,AvaliableTable2 avaliableTable);
    }
}
