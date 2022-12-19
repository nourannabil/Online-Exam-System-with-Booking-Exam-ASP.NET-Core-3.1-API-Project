using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class LoginTable2
    {
        public decimal Loginid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Userid { get; set; }

        public virtual RoleTable2 Role { get; set; }
        public virtual UserTable2 User { get; set; }
    }
}
