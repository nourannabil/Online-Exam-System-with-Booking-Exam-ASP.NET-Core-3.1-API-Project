using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class Register
    {
        // User Table
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Imagepath { get; set; }

        // Login Table
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }

    }
}
