using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class InvoiceService : IGenericService<InvoiceTable2>
    {
        private readonly IGenericRepository<InvoiceTable2> _genericRepository;

        public InvoiceService(IGenericRepository<InvoiceTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(InvoiceTable2 invoiceTable)
        {
            _genericRepository.Create(invoiceTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<InvoiceTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public InvoiceTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(InvoiceTable2 invoiceTable)
        {
            _genericRepository.Update(invoiceTable);
        }
    }
}
