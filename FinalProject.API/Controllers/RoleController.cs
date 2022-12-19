using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<RoleTable2>
    {
        public RoleController(IGenericService<RoleTable2> genericService) : base(genericService)
        {
        }
    }
}
