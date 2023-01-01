using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IGenericRepository<LoginTable2> _loginRepository;

        public RegisterService(IRegisterRepository registerRepository, IGenericRepository<LoginTable2> loginRepository)
        {
            _registerRepository = registerRepository;
            _loginRepository = loginRepository; 
        }

        public List<UserTable2> CheckUserEmail(string useremail)
        {
            return _registerRepository.CheckUserEmail(useremail);
        }

        public List<UserTable2> CheckUserName(string username)
        {
           return _registerRepository.CheckUserName(username);
        }

        public bool Register(Register register)
        {
            
                _registerRepository.Register(register);

                // here will create the Login
                LoginTable2 newLogin = new LoginTable2();
                newLogin.Username = register.Username;
                newLogin.Password = register.Password;
                newLogin.Roleid = 2;
                newLogin.Userid = register.UserId;

                _loginRepository.Create(newLogin);
                return true;
         

        }
    }
}


//var Logins = _loginRepository.GetAll().ToList();
//bool findUsername = false;

//foreach (var login in Logins)
//{
//    if (login.Username == register.Username)
//    {
//        findUsername = true;
//        return false;
//    }
//}

//if (findUsername == false)
//{
//    _registerRepository.Register(register);

//    // here will create the Login
//    LoginTable2 newLogin = new LoginTable2();
//    newLogin.Username = register.Username;
//    newLogin.Password = register.Password;
//    newLogin.Roleid = 2;
//    newLogin.Userid = register.UserId;

//    _loginRepository.Create(newLogin);
//    return true;
//}
//else
//{
//    return false;
//}
