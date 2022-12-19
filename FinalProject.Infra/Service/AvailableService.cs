using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class AvailableService : IGenericService<AvaliableTable2> , IAvailableService
    {
        private readonly IGenericRepository<AvaliableTable2> _genericRepository;
        private readonly IAvailableRepository _availableRepository;
        public AvailableService(IGenericRepository<AvaliableTable2> genericRepository, IAvailableRepository availableRepository)
        {
            _genericRepository = genericRepository;
            _availableRepository = availableRepository;
        }

        public void Create(AvaliableTable2 availableTable)
        {
            _genericRepository.Create(availableTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<AvaliableTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public AvaliableTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(AvaliableTable2 availableTable)
        {
            _genericRepository.Update(availableTable);
        }

        public List<AvaliableTable2> GetAllAvaliableTimeForEachExam(int examId)
        {
            return _availableRepository.GetAllAvaliableTimeForEachExam(examId);
        }

        public void AddTimeForExam(int examId, AvaliableTable2 avaliableTable)
        {
            _availableRepository.AddTimeForExam(examId, avaliableTable);
        }
    }
}
