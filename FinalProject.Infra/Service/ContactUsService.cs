using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using FinalProject.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class ContactUsService : IGenericService<ContactUsTable2>
    {
        private readonly IGenericRepository<ContactUsTable2> _genericRepository;

        public ContactUsService(IGenericRepository<ContactUsTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(ContactUsTable2 contactUsTable)
        {
            _genericRepository.Create(contactUsTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<ContactUsTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public ContactUsTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(ContactUsTable2 contactUsTable)
        {
            _genericRepository.Update(contactUsTable);
        }
    }
}
