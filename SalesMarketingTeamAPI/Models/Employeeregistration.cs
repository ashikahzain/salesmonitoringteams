using System;
using System.Collections.Generic;

namespace SalesMarketingTeamAPI.Models
{
    public partial class Employeeregistration
    {
        public Employeeregistration()
        {
            Visittable = new HashSet<Visittable>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<Visittable> Visittable { get; set; }
    }
}
