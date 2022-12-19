using FinalProject.Core.DTO;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jWTService;

        public JWTController(IJWTService jWTService)
        {
            _jWTService = jWTService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin(JWT jwt)
        {
            var token = _jWTService.UserLogin(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }



        }
    }
}
