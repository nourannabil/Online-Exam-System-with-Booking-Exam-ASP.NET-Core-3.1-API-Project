using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;

namespace FinalProject.Core.Repository
{
    public interface IRegisterRepository
    {
        int Register(Register register );
        List<UserTable2> CheckUserName(string username);
        List<UserTable2> CheckUserEmail(string useremail);
    }
}
