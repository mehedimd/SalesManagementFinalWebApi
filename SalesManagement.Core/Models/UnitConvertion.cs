using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace SalesManagement.Core.Models
{
    public partial class UnitConvertion
    {
        public int UnitConvertionId { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ValidateNever]
        public virtual Product Product { get; set; } = null!;
        [ValidateNever]
        public virtual Unit Unit { get; set; } = null!;
    }
}
