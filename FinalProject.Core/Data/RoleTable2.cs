using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class RoleTable2
    {
        public RoleTable2()
        {
            LoginTable2s = new HashSet<LoginTable2>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<LoginTable2> LoginTable2s { get; set; }
    }
}
