using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IEmployeeRepository Employees { get; }
        public IOrderRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }
        public IPharmacyRepository Pharmacies { get; }
        public ISalesAchivementRepository SalesAchivmants { get; }
        public ISalesTargetRepository SalesTargets { get; }
        public IUnitRepository Units { get; }
        public IUnitConversionRepository UnitConversions { get; }
        int Save();
    }
}
