using System;
using System.Collections.Generic;

namespace SalesMarketingTeamAPI.Models
{
    public partial class Login
    {
        public Login()
        {
            Employeeregistration = new HashSet<Employeeregistration>();
        }

        public int LId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Employeeregistration> Employeeregistration { get; set; }
    }
}
