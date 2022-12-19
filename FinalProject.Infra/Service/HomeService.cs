using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class HomeService : IGenericService<HomeTable2>
    {
        private readonly IGenericRepository<HomeTable2> _genericRepository;

        public HomeService(IGenericRepository<HomeTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(HomeTable2 homeTable)
        {
            _genericRepository.Create(homeTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<HomeTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public HomeTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(HomeTable2 homeTable)
        {
            _genericRepository.Update(homeTable);
        }
    }
}
