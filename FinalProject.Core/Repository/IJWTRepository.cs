using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public  interface IJWTRepository
    {
        JWT UserLogin(JWT jwt);
    }
}
