using System;
using System.Collections.Generic;

namespace SalesMarketingTeamAPI.Models
{
    public partial class Visittable
    {
        public int VisitId { get; set; }
        public string CustName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string InterestProduct { get; set; }
        public string VisitSubject { get; set; }
        public string Description { get; set; }
        public DateTime? VisitDatetime { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsDeleted { get; set; }
        public int? EmpId { get; set; }

        public virtual Employeeregistration Emp { get; set; }
    }
}
