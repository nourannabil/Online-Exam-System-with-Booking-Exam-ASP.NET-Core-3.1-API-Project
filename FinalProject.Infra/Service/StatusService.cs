using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using FinalProject.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class StatusService : IGenericService<StatusTable2>
    {
        private readonly IGenericRepository<StatusTable2> _genericRepository;

        public StatusService(IGenericRepository<StatusTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(StatusTable2 statusTable)
        {
            _genericRepository.Create(statusTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<StatusTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public StatusTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(StatusTable2 statusTable)
        {
            _genericRepository.Update(statusTable);
        }
    }
}
