using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Service
{
    public interface IAvailableService
    {
        List<AvaliableTable2> GetAllAvaliableTimeForEachExam(int examId);
        void AddTimeForExam(int examId, AvaliableTable2 avaliableTable);
    }
}
