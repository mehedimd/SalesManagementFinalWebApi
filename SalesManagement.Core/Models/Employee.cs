using System;
using System.Collections.Generic;

namespace SalesManagement.Core.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
            SalesTargets = new HashSet<SalesTarget>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Gender { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SalesTarget> SalesTargets { get; set; }
    }
}
