using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
namespace SalesManagement.Core.Models
{
    public partial class Product
    {
        public Product()
        {
 
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public virtual Category Category { get; set; } = null!;

    }
}
