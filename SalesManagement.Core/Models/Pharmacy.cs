using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Core.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Orders = new HashSet<Order>();
        }

        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        [ForeignKey("PharmacyRoute")]
        public int RouteId { get; set; }
        public PharmacyRoute? PharmacyRoute { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
