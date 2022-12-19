using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaController : GenericController<VisaTable2>
    {
        public VisaController(IGenericService<VisaTable2> genericService) : base(genericService)
        {

        }
    }
}

