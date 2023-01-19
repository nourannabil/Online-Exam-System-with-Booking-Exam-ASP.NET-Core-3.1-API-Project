using FinalProject.Core.Data;
using FinalProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<UserTable2>
    {
        private readonly IUserService _userService;
        public UserController(IGenericService<UserTable2> genericService , IUserService userService) : base(genericService)
        {
            _userService = userService; 
        }

        [HttpGet]
        [Route("GetMyProfile/{userId}")]
        public UserTable2 GetMyProfile(int userId)
        {
            return _userService.GetMyProfile(userId);
        }

        [HttpPut]
        [Route("EditMyProfile/{userId}")]
        public void EditMyProfile(int userId, UserTable2 userTable)
        {
            _userService.EditMyProfile(userId, userTable);
        }

        [HttpPost]
        [Route("UplodeImage")]
        public UserTable2 UplodeImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\hanee\\OneDrive\\Desktop\\NouranStudy\\Final Project\\FinalProject12-12\\12-12Version\\ExamBooking\\src\\assets\\images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            UserTable2 user = new UserTable2();
            user.Imagepath = fileName;
            return user;
        }
    }
}
