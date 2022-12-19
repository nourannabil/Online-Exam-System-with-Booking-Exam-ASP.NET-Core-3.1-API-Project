using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : GenericController<LoginTable2>
    {
        public LoginController(IGenericService<LoginTable2> genericService) : base(genericService)
        {
        }
    }
}
