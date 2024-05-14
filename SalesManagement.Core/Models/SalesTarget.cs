using System;
using System.Collections.Generic;

namespace SalesManagement.Core.Models
{
    public partial class SalesTarget
    {
        public SalesTarget()
        {
            SalesAchivements = new HashSet<SalesAchivement>();
        }

        public int SalesTargetId { get; set; }
        public int EmployeeId { get; set; }
        public decimal TargetTaka { get; set; }
        public DateTime ClosingDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<SalesAchivement> SalesAchivements { get; set; }
    }
}
