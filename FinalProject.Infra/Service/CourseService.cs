using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class CourseService : IGenericService<CourseTable2>
    {
        private readonly IGenericRepository<CourseTable2> _genericRepository;

        public CourseService(IGenericRepository<CourseTable2> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void Create(CourseTable2 courseTable)
        {
            _genericRepository.Create(courseTable);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public List<CourseTable2> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public CourseTable2 GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(CourseTable2 courseTable)
        {
            _genericRepository.Update(courseTable);
        }
    }
}
