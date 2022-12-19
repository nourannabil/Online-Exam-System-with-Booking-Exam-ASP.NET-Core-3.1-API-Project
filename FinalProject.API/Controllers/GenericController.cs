using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase
    {
        private readonly IGenericService<T> _GenericService;

        public GenericController(IGenericService<T> genericService)
        {
            _GenericService = genericService;
        }

        [HttpPost]
        public void Create(T t)
        {
            _GenericService.Create(t);
        }

        [HttpDelete]
        //[Route("{id}")]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _GenericService.Delete(id);
        }

        [HttpGet]
        public List<T> GetAll()
        {
            return _GenericService.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public T GetById(int id)
        {
            return _GenericService.GetById(id);
        }

        [HttpPut]
        public void Update(T t)
        {
            _GenericService.Update(t);
        }
    }
}
