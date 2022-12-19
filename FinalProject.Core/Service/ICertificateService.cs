using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Service
{
    public interface ICertificateService
    {
        List<MyCertificate> GetMyCertificate(int userId);
    }
}
