using System;
using System.Collections.Generic;

namespace SalesManagement.Core.Models
{
    public partial class Unit
    {
        public Unit()
        {
            UnitConvertions = new HashSet<UnitConvertion>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;

        public virtual ICollection<UnitConvertion> UnitConvertions { get; set; }
    }
}
