using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Service
{
    public interface IRegisterService
    {
        bool Register(Register register);
        List<UserTable2> CheckUserName(string username);
        List<UserTable2> CheckUserEmail(string useremail);
    }
}
