using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class VisaService : IGenericService<VisaTable2>
    {
        private readonly IGenericRepository<VisaTable2> _genericRepository;

        public VisaService(IGenericRepository<VisaTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(VisaTable2 visaTable)
        {
            _genericRepository.Create(visaTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<VisaTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public VisaTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(VisaTable2 visaTable)
        {
            _genericRepository.Update(visaTable);
        }
    }
}
