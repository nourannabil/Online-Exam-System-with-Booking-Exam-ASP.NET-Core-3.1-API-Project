using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class UserService : IGenericService<UserTable2>, IUserService
    {
        private readonly IGenericRepository<UserTable2> _genericRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IGenericRepository<UserTable2> genericRepository, IUserRepository userRepository)
        {
            _genericRepository = genericRepository;
            _userRepository = userRepository;
        }
        public void Create(UserTable2 userTable)
        {
            _userRepository.Create(userTable);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public List<UserTable2> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserTable2 GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(UserTable2 userTable)
        {
            _userRepository.Update(userTable);
        }

        public UserTable2 GetMyProfile(int userId)
        {
            return _userRepository.GetMyProfile(userId);
        }

        public void EditMyProfile(int userId, UserTable2 userTable)
        {
            _userRepository.EditMyProfile(userId, userTable);
        }
    }
}
