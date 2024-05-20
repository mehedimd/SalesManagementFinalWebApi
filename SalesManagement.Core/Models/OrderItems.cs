using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Core.Models
{
    public class OrderItems
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int UnitId {  get; set; }
        public virtual Unit? unit {  get; set; }

        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
        

    }
}
