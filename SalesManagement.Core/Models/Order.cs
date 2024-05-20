using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Core.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItems>();
        }
        public int OrderId { get; set; }
        public long OrderNo {  get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public decimal GrandTotal { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsDelivered { get; set; } = false;

        public int PharmacyId { get; set; }
        public virtual Pharmacy? Pharmacy { get; set; }
        public virtual List<OrderItems>? OrderItems { get; set; }
    }
}
