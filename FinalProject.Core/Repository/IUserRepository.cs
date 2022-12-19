using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IUserRepository : IGenericRepository<UserTable2>
    {
        UserTable2 GetMyProfile(int userId);
        void EditMyProfile(int userId , UserTable2 userTable);

    }
}
