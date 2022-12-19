using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class AboutService : IGenericService<AboutTable2> 
    {
        private readonly IGenericRepository<AboutTable2> _genericRepository;

        public AboutService(IGenericRepository<AboutTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(AboutTable2 aboutTable)
        {
            _genericRepository.Create(aboutTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<AboutTable2> GetAll()
        {
           return _genericRepository.GetAll();
        }

        public AboutTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(AboutTable2 aboutTable)
        {
            _genericRepository.Update(aboutTable);
        }
    }
}
