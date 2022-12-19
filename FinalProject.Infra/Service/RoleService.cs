using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class RoleService:IGenericService<RoleTable2>
    {

        private readonly IGenericRepository<RoleTable2> _genericRepository;

        public RoleService(IGenericRepository<RoleTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(RoleTable2 roleTble)
        {
            _genericRepository.Create(roleTble);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<RoleTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public RoleTable2 GetById(int id)
        {
            return  _genericRepository.GetById(id);
        }

        public void Update(RoleTable2 roleTble)
        {
            _genericRepository.Update(roleTble);
        }
    }
}
