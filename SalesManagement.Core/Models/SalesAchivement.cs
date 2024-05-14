using System;
using System.Collections.Generic;

namespace SalesManagement.Core.Models
{
    public partial class SalesAchivement
    {
        public int ID { get; set; }
        public int SalesTargetsId { get; set; }
        public decimal Amount { get; set; }

        public virtual SalesTarget SalesTargets { get; set; } = null!;
    }
}
