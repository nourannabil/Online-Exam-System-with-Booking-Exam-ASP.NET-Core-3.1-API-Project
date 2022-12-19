using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        [Route("Register")]
        public void Register(Register register)
        {
            _registerService.Register(register);

        }

        [HttpGet]
        [Route("CheckUserName/{username}")]
        public List<UserTable2> CheckUserName(string username)
        {
            return _registerService.CheckUserName(username);
        }

        [HttpGet]
        [Route("CheckUserEmail/{useremail}")]
        public List<UserTable2> CheckUserEmail(string useremail)
        {
            return _registerService.CheckUserEmail(useremail);
        }
    }
}
