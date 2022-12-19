using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using FinalProject.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class ContactFormService : IGenericService<ContactUsForm2>
    {
        private readonly IGenericRepository<ContactUsForm2> _genericRepository;

        public ContactFormService(IGenericRepository<ContactUsForm2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(ContactUsForm2 contactForm)
        {
            _genericRepository.Create(contactForm);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<ContactUsForm2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public ContactUsForm2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(ContactUsForm2 contactForm)
        {
            _genericRepository.Update(contactForm);
        }
    }
}
