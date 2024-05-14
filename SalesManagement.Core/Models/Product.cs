using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
namespace SalesManagement.Core.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            UnitConvertions = new HashSet<UnitConvertion>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UnitConvertion> UnitConvertions { get; set; }
    }
}
