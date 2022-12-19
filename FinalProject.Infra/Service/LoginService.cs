using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class LoginService : IGenericService<LoginTable2>
    {
        private readonly IGenericRepository<LoginTable2> _genericRepository;

        public LoginService(IGenericRepository<LoginTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(LoginTable2 loginTable)
        {
            _genericRepository.Create(loginTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<LoginTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public LoginTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(LoginTable2 loginTable)
        {
            _genericRepository.Update(loginTable);
        }
    }
}
