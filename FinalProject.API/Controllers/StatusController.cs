using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : GenericController<StatusTable2>
    {
        public StatusController(IGenericService<StatusTable2> genericService) : base(genericService)
        {
        }
    }
}
