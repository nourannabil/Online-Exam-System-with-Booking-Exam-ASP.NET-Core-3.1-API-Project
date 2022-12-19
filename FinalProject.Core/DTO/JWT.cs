using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DTO
{
    public class JWT
    {
        // from user table
        public decimal Userid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Imagepath { get; set; }
        // from login table 
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }


    }
}
