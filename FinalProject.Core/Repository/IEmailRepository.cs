using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface IEmailRepository
    {
        void SendEmail(int id);
    }
}
